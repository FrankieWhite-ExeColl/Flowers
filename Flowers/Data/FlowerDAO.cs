using Flowers.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Flowers.Data
{
    internal class FlowerDAO
    {
        private string connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=FlowersDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        // performs all operations on the database. get all, create, delete, get one, search etc.

        public List<FlowersModel> FetchAll()
        {
            List<FlowersModel> returnList = new List<FlowersModel>();
            // access the database

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string sqlQuery = "SELECT * from dbo.Flowers";

                SqlCommand command = new SqlCommand(sqlQuery, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //create a new flower object.  Add it to the list to return.  
                        FlowersModel flower = new FlowersModel();
                        flower.Id = reader.GetInt32(0);
                        flower.Name = reader.GetString(1);
                        flower.Flowering = reader.GetString(2);
                        flower.Colour = reader.GetString(3);
                        flower.Size = reader.GetInt32(4);

                        returnList.Add(flower);
                    }
                }

            }
            return returnList;
        }

        public int Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string sqlQuery = "DELETE FROM dbo.Flowers WHERE ID = @Id";

                SqlCommand command = new SqlCommand(sqlQuery, connection);
  
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;
  
                connection.Open();

                int deletedId = command.ExecuteNonQuery();

                return deletedId;

            }

        }

        public List<FlowersModel> SearchForName(string searchPhrase)
        {
            List<FlowersModel> returnList = new List<FlowersModel>();
            // access the database

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string sqlQuery = "SELECT * from dbo.Flowers WHERE NAME LIKE @searchForMe";
                

                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.Add("@searchForMe", System.Data.SqlDbType.NVarChar).Value = "%" + searchPhrase + "%";
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //create a new flower object.  Add it to the list to return.  
                        FlowersModel flower = new FlowersModel();
                        flower.Id = reader.GetInt32(0);
                        flower.Name = reader.GetString(1);
                        flower.Flowering = reader.GetString(2);
                        flower.Colour = reader.GetString(3);
                        flower.Size = reader.GetInt32(4);

                        returnList.Add(flower);
                    }
                }

            }
            return returnList;
        }
    

        public FlowersModel FetchOne(int Id)
        {
            FlowersModel flower = new FlowersModel();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * from dbo.Flowers Where Id = @Id";
                //associate @ id with parameter

                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = Id;



                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

               

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //create a new flower object.  Add it to the list to return. 
                        flower.Id = reader.GetInt32(0);
                        flower.Name = reader.GetString(1);
                        flower.Flowering = reader.GetString(2);
                        flower.Colour = reader.GetString(3);
                        flower.Size = reader.GetInt32(4);
                        
                    }

                }
            }
         
            return flower;
        }

        public int CreateOrUpdate(FlowersModel flowersModel)
        {
            // if flower.id is <= 1 than create

            // if flower.id is>1 then update is 

            FlowersModel flower = new FlowersModel();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "";
                if (flowersModel.Id <= 0)
                {
                    sqlQuery = "INSERT INTO dbo.Flowers Values(@Name, @Flowering, @Colour, @Size)";
                }
                else
                {
                    // update
                    sqlQuery = "UPDATE dbo.Flowers SET Name = @Name, Flowering = @Flowering, Colour = @Colour, Size = @Size WHERE Id = @Id";
                }

                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = flowersModel.Id;
                command.Parameters.Add("@Name", System.Data.SqlDbType.VarChar, 1000).Value = flowersModel.Name;
                command.Parameters.Add("@Flowering", System.Data.SqlDbType.VarChar, 1000).Value = flowersModel.Flowering;
                command.Parameters.Add("@Colour", System.Data.SqlDbType.VarChar, 1000).Value = flowersModel.Colour;
                command.Parameters.Add("@Size", System.Data.SqlDbType.VarChar).Value = flowersModel.Size;

                connection.Open();

                int newId = command.ExecuteNonQuery();

                return newId;

            }
        }
    }
}