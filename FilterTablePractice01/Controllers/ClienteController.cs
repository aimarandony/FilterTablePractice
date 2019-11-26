using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FilterTablePractice01.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FilterTablePractice01.Controllers
{
    public class ClienteController : Controller
    {
        SqlConnection cn = new SqlConnection(
            ConfigurationManager.ConnectionStrings["cadena"].ConnectionString);

        List<Cliente> ClientesNombre(string nombre)
        {
            List<Cliente> temporal = new List<Cliente>();

            SqlCommand cmd = new SqlCommand("USP_CLIENTES_NOMBRE", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre", nombre);

            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                Cliente reg = new Cliente
                {
                    idcli = dr.GetInt32(0),
                    nomcli= dr.GetString(1),
                    apecli = dr.GetString(2),
                    iddist = dr.GetInt32(3),
                    fecha_reg = dr.GetDateTime(4),
                    estado = dr.GetInt32(5),
                };
                temporal.Add(reg);
            }
            dr.Close(); cn.Close();
            return temporal;
        }

        public ActionResult ClientesporNombre(string nombre="")
        {
            ViewBag.nombre = nombre;
            return View(ClientesNombre(nombre));
        }

        List<Cliente> ClientesFecha(int fecha)
        {
            List<Cliente> temporal = new List<Cliente>();

            SqlCommand cmd = new SqlCommand("USP_CLIENTES_FECHA", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fecha", fecha);

            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Cliente reg = new Cliente
                {
                    idcli = dr.GetInt32(0),
                    nomcli = dr.GetString(1),
                    apecli = dr.GetString(2),
                    nomdist = dr.GetString(3),
                    fecha_reg = dr.GetDateTime(4),
                    estado = dr.GetInt32(5),
                };
                temporal.Add(reg);
            }
            dr.Close(); cn.Close();
            return temporal;
        }

        public ActionResult ClientesporFecha(int fecha = 0)
        {
            ViewBag.fecha = fecha;
            return View(ClientesFecha(fecha));
        }

        List<Cliente> ClientesNombreFecha(string nombre, int fecha)
        {
            List<Cliente> temporal = new List<Cliente>();

            SqlCommand cmd = new SqlCommand("USP_CLIENTES_NOMBRE_FECHA", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@fecha", fecha);

            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Cliente reg = new Cliente
                {
                    idcli = dr.GetInt32(0),
                    nomcli = dr.GetString(1),
                    apecli = dr.GetString(2),
                    nomdist = dr.GetString(3),
                    fecha_reg = dr.GetDateTime(4),
                    estado = dr.GetInt32(5),
                };
                temporal.Add(reg);
            }
            dr.Close(); cn.Close();
            return temporal;
        }

        public ActionResult ClientesporNombreFecha(string nombre = "", int fecha = 0)
        {
            ViewBag.nombre = nombre;
            ViewBag.fecha = fecha;
            return View(ClientesNombreFecha(nombre, fecha));
        }
    }
}