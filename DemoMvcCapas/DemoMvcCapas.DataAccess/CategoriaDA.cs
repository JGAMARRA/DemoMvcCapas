using DemoMvcCapas.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoMvcCapas.BusinessEntities;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DemoMvcCapas.DataAccess
{
    public class CategoriaDA : ICategoriaDA
    {
        string connectionString = ConfigurationManager.ConnectionStrings["CnDatabase"].ConnectionString;

        public bool Delete(CategoriaBE entity)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                string sql = "Delete Categoria where IdCategoria=@IdCategoria)";
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@IdCategoria", entity.IdCategoria);            
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    int execute = cmd.ExecuteNonQuery();
                    cn.Close();
                    return (execute > 0);
                }
            }
        }
        public CategoriaBE Get(int id)
        {
            CategoriaBE entity = new CategoriaBE();
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                string sql = "Select IdCategoria, Nombre, Descripcion from Categoria Order By IdCategoria";
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if(dr.Read())
                    {
                        entity.IdCategoria = (int)dr["IdCategoria"];
                        entity.Nombre = (string)dr["Nombre"];
                        entity.Descripcion = (string)dr["Descripcion"];
                    }
                    cn.Close();
                    return entity;
                }
            }
        }
     
        public List<CategoriaBE> GetAll()
        {
            List<CategoriaBE> list = new List<CategoriaBE>();
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                string sql = "Select IdCategoria, Nombre, Descripcion from Categoria Order By IdCategoria";
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        list.Add(
                            new CategoriaBE {
                                IdCategoria = (int)dr["IdCategoria"],
                                Nombre = (string)dr["Nombre"],
                                Descripcion = (string)dr["Descripcion"],
                            }
                        );
                    }
                    cn.Close();
                    return list;
                }
            }
        }
     
        public bool Insert(CategoriaBE entity)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                string sql = "Inser Into Categoria (Nombre, Descripcion) Values (@Nombre, @Descripcion)";
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@Nombre", entity.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", entity.Descripcion);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    int execute = cmd.ExecuteNonQuery();
                    cn.Close();
                    return (execute > 0);
                }
            }
        }
        public bool Update(CategoriaBE entity)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                string sql = "Update Categoria set Nombre=@Nombre, Descripcion=@Descripcion where IdCategoria=@IdCategoria)";
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@IdCategoria", entity.IdCategoria);
                    cmd.Parameters.AddWithValue("@Nombre", entity.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", entity.Descripcion);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    int execute = cmd.ExecuteNonQuery();
                    cn.Close();
                    return (execute > 0);
                }
            }
        }
    }
}
