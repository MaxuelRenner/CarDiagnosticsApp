using CarDiagnosticsApp.MVVM.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDiagnosticsApp.MVVM.Model
{
    static class DB_Connection
    {
        public static string conectionstring = "Data Source=DESKTOP-NUC9HR1\\SQLEXPRESS;Initial Catalog=CarDiagnosticsApp;Integrated Security=True";
        public static ObservableCollection<Vehicle> DisplayType(string type)
        {
            ObservableCollection<Vehicle> vehicles = new ObservableCollection<Vehicle>();
            Vehicle vehicle = null;
            string queryString = "Select * from [AddVehicle-1] where TypeID =(select ID from [VehicleType-2] Where Type = @type )";
            using (SqlConnection connection = new SqlConnection(conectionstring))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("type", type);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        vehicle = new Vehicle(
                            reader.GetInt32(reader.GetOrdinal("ID")),
                            reader.GetInt32(reader.GetOrdinal("TypeID")),
                            reader.GetString(reader.GetOrdinal("Brand")),
                            reader.GetString(reader.GetOrdinal("Model")),
                            reader.GetString(reader.GetOrdinal("Generation")),
                            reader.GetString(reader.GetOrdinal("Fule")),
                            reader.GetString(reader.GetOrdinal("Mileage")),
                            reader.GetString(reader.GetOrdinal("LicensePlate")));
                        vehicles.Add(vehicle);
                    }
                }
                connection.Close();
            }
            return vehicles;
        }

        public static ObservableCollection<FixTypes> GetAllFixTypes()
        {
            ObservableCollection<FixTypes> fixTypes = new ObservableCollection<FixTypes>();
            string queryString = "Select * from [FixType-4]";
            using (SqlConnection connection = new SqlConnection(conectionstring))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        fixTypes.Add(new FixTypes(
                            reader.GetInt32(reader.GetOrdinal("ID")),
                            reader.GetString(reader.GetOrdinal("TypeOfFixChoise"))));
                    }
                }
                connection.Close();
            }
            return fixTypes;
        }

        public static void Insert(Vehicle vehicle)
        {
            using (SqlConnection connection = new SqlConnection(conectionstring))
            {
                connection.Open();
                string query = "INSERT INTO [AddVehicle-1] (TypeID,Brand,Model,Generation,Fule,Mileage,LicensePlate) SELECT TypeID=@typeID,Brand=@brand,Model=@model,Generation=@generation,Fule=@fule,Mileage=@mileage,LicensePlate=@licenseplate";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("TypeID", vehicle.typeid);
                command.Parameters.AddWithValue("Brand", vehicle.brand);
                command.Parameters.AddWithValue("Model", vehicle.model);
                command.Parameters.AddWithValue("Generation", vehicle.generation);
                command.Parameters.AddWithValue("Fule", vehicle.fuel);
                command.Parameters.AddWithValue("Mileage", vehicle.mileage);
                command.Parameters.AddWithValue("LicensePlate", vehicle.plate);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static void Update(Vehicle vehicle)
        {
            using (SqlConnection connection = new SqlConnection(conectionstring))
            {
                connection.Open();
                string query = " UPDATE [AddVehicle-1] SET TypeID=@TypeID,Brand=@Brand,Model=@Model,Generation=@Generation,Fule=@Fule,Mileage=@Mileage,LicensePlate=@LicensePlate WHERE id=@ID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("ID", vehicle.id);
                    command.Parameters.AddWithValue("TypeID", vehicle.typeid);
                    command.Parameters.AddWithValue("Brand", vehicle.brand);
                    command.Parameters.AddWithValue("Model", vehicle.model);
                    command.Parameters.AddWithValue("Generation", vehicle.generation);
                    command.Parameters.AddWithValue("Fule", vehicle.fuel);
                    command.Parameters.AddWithValue("Mileage", vehicle.mileage);
                    command.Parameters.AddWithValue("LicensePlate", vehicle.plate);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public static void AddFix(NewFixes newFixes)
        {
            using (SqlConnection connection = new SqlConnection(conectionstring))
            {
                connection.Open();
                string query = "INSERT INTO [FixSections-3] (RepairID,SelectedCarID,DateOfFix,Mileage,Price,MechanicsName,SerivceNameAddress,Description) SELECT RepairID = @repairID,SelectedCarID = @selectedCarID,DateOfFix = @dateOfFix,Mileage = @mileage,Price = @price,MechanicsName = @mechanicsName,SerivceNameAddress = @serivceNameAddress,Description = @description";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("RepairID", newFixes.repairid);
                command.Parameters.AddWithValue("SelectedCarID", newFixes.selectedcarid);
                command.Parameters.AddWithValue("DateOfFix", newFixes.data);
                command.Parameters.AddWithValue("Mileage", newFixes.mileage);
                command.Parameters.AddWithValue("Price", newFixes.price);
                command.Parameters.AddWithValue("MechanicsName", newFixes.mechanicsname);
                command.Parameters.AddWithValue("serivceNameAddress", newFixes.serivcenameaddress);
                command.Parameters.AddWithValue("Description", newFixes.description);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static ObservableCollection<NewFixes> DisplayFixes(int id)
        {
            ObservableCollection<NewFixes> fixes = new ObservableCollection<NewFixes>();
            string queryString = "SELECT fix3.ID ,fix4.TypeOfFixChoise,fix3.SelectedCarID, fix3.DateOfFix, fix3.Mileage, fix3.Price, fix3.MechanicsName, fix3.SerivceNameAddress, fix3.Description \r\nFROM [FixSections-3] as fix3 \r\nINNER JOIN [FixType-4]  as fix4\r\nON  fix3.RepairID = fix4.ID \r\nWHERE fix3.SelectedCarID = @id;";
            using (SqlConnection connection = new SqlConnection(conectionstring))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                command.Parameters.AddWithValue("id", id);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        fixes.Add(new NewFixes(
                                       reader.GetString(reader.GetOrdinal("TypeOfFixChoise")),
                                       reader.GetInt32(reader.GetOrdinal("SelectedCarID")),
                                       reader.GetString(reader.GetOrdinal("DateOfFix")),
                                       reader.GetString(reader.GetOrdinal("Mileage")),
                                       reader.GetString(reader.GetOrdinal("Price")),
                                       reader.GetString(reader.GetOrdinal("MechanicsName")),
                                       reader.GetString(reader.GetOrdinal("SerivceNameAddress")),
                                       reader.GetString(reader.GetOrdinal("Description"))));

                    }
                }
                connection.Close();
            }
            return fixes;
        }
        public static ObservableCollection<Type> GetTypes()
        {
            ObservableCollection<Type> types = new ObservableCollection<Type>();
            string queryString = "SELECT * FROM [VehicleType-2]";
            using (SqlConnection connection = new SqlConnection(conectionstring))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        types.Add(new Type(reader.GetInt32(reader.GetOrdinal("ID")),
                            reader.GetString(reader.GetOrdinal("Type"))));
                    }
                }
                connection.Close();
            }
            return types;
        }

        public static ObservableCollection<Vehicle> GetCarsOnly()
        {
            ObservableCollection<Vehicle> cars = new ObservableCollection<Vehicle>();
            string queryString = "SELECT * FROM [AddVehicle-1] Where TypeID = 1";
            using (SqlConnection connection = new SqlConnection(conectionstring))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cars.Add(new Vehicle(reader.GetInt32(reader.GetOrdinal("ID")),
                            reader.GetInt32(reader.GetOrdinal("TypeID")),
                            reader.GetString(reader.GetOrdinal("Brand")),
                            reader.GetString(reader.GetOrdinal("Model")),
                            reader.GetString(reader.GetOrdinal("Generation")),
                            reader.GetString(reader.GetOrdinal("Fule")),
                            reader.GetString(reader.GetOrdinal("Mileage")),
                            reader.GetString(reader.GetOrdinal("LicensePlate"))));
                    }
                }
                connection.Close();
            }
            return cars;
        }

        public static ObservableCollection<Vehicle> GetMotorsOnly()
        {
            ObservableCollection<Vehicle> motors = new ObservableCollection<Vehicle>();
            string queryString = "SELECT * FROM [AddVehicle-1] Where TypeID = 2";
            using (SqlConnection connection = new SqlConnection(conectionstring))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        motors.Add(new Vehicle(reader.GetInt32(reader.GetOrdinal("ID")),
                            reader.GetInt32(reader.GetOrdinal("TypeID")),
                            reader.GetString(reader.GetOrdinal("Brand")),
                            reader.GetString(reader.GetOrdinal("Model")),
                            reader.GetString(reader.GetOrdinal("Generation")),
                            reader.GetString(reader.GetOrdinal("Fule")),
                            reader.GetString(reader.GetOrdinal("Mileage")),
                            reader.GetString(reader.GetOrdinal("LicensePlate"))));
                    }
                }
                connection.Close();
            }
            return motors;
        }

        public static ObservableCollection<Vehicle> GetBusesOnly()
        {
            ObservableCollection<Vehicle> buses = new ObservableCollection<Vehicle>();
            string queryString = "SELECT * FROM [AddVehicle-1] Where TypeID = 3";
            using (SqlConnection connection = new SqlConnection(conectionstring))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        buses.Add(new Vehicle(reader.GetInt32(reader.GetOrdinal("ID")),
                            reader.GetInt32(reader.GetOrdinal("TypeID")),
                            reader.GetString(reader.GetOrdinal("Brand")),
                            reader.GetString(reader.GetOrdinal("Model")),
                            reader.GetString(reader.GetOrdinal("Generation")),
                            reader.GetString(reader.GetOrdinal("Fule")),
                            reader.GetString(reader.GetOrdinal("Mileage")),
                            reader.GetString(reader.GetOrdinal("LicensePlate"))));
                    }
                }
                connection.Close();
            }
            return buses;
        }

        public static ObservableCollection<Vehicle> GetVehicles()
        {
            ObservableCollection<Vehicle> vehicles = new ObservableCollection<Vehicle>();
            string queryString = "SELECT * FROM [AddVehicle-1]";
            using (SqlConnection connection = new SqlConnection(conectionstring))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        vehicles.Add(new Vehicle(
                            reader.GetInt32(reader.GetOrdinal("ID")),
                            reader.GetInt32(reader.GetOrdinal("TypeID")),
                            reader.GetString(reader.GetOrdinal("Brand")),
                            reader.GetString(reader.GetOrdinal("Model")),
                            reader.GetString(reader.GetOrdinal("Generation")),
                            reader.GetString(reader.GetOrdinal("Fule")),
                            reader.GetString(reader.GetOrdinal("Mileage")),
                            reader.GetString(reader.GetOrdinal("LicensePlate"))));
                    }
                }
                connection.Close();
            }
            return vehicles;
        }

        public static void DeleteVehicle(string brand)
        {
            using (SqlConnection connection = new SqlConnection(conectionstring))
            {
                connection.Open();
                string query = "SET ROWCOUNT 1 DELETE FROM [AddVehicle-1] WHERE brand = @brand SET ROWCOUNT 0";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Brand", brand);
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
