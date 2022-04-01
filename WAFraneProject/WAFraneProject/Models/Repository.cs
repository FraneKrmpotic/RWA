using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace WAFraneProject.Models
{
    public class Repository
    {
        public static DataSet ds { get; set; }
        private static string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString; 

        // User account ---------------------------------------------
        public static int CreateUserAccount(UserAccount userAccount) => SqlHelper.ExecuteNonQuery(cs, "CreateUserAccount", userAccount.Username, userAccount.Password, userAccount.IDUserAccount);

        public static int GetUserAccountCount(string username, string password)
        {
            return (int)SqlHelper.ExecuteScalar(cs, "CountUserAccounts", username, password);
        }

        //Clients ---------------------------------------------------
        public static IEnumerable<Client> GetAllClients()
        {
            ds = SqlHelper.ExecuteDataset(cs, "GetAllClients");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                yield return GetClientFromDataRow(row);
            }
        }

        public static Client GetClient(int IDClient)
        {
            DataRow row = SqlHelper.ExecuteDataset(cs, "GetClient", IDClient).Tables[0].Rows[0];
            return GetClientFromDataRow(row);
        }

        public static IEnumerable<Client> GetClientsByCity(int IDCity)
        {
            ds = SqlHelper.ExecuteDataset(cs, "GetClientsByCity", IDCity);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                yield return GetClientFromDataRow(row);
            }
        }

        private static Client GetClientFromDataRow(DataRow row)
        {
            return new Client
            {
                IDClient = (int)row["IDKupac"],
                FirstName = row["Ime"].ToString(),
                LastName = row["Prezime"].ToString(),
                Email = row["Email"].ToString(),
                Phone = row["Telefon"].ToString(),
                CityID = row["GradID"] != DBNull.Value ? (int)row["GradID"] : 1,
                City = row["Grad"] != DBNull.Value ? row["Grad"].ToString() : string.Empty,
                Country = row["Drzava"] != DBNull.Value ? row["Drzava"].ToString() : string.Empty
            };
        }

        public static int UpdateKupac(Client client) 
        => SqlHelper.ExecuteNonQuery(cs, "UpdateClient", client.IDClient, client.FirstName, client.LastName, client.Email, client.Phone, client.CityID);

        //ItemDetails -----------------------------------------------
        public static IEnumerable<ItemDetails> GetItemDetails(int IDReceipt)
        {
            ds = SqlHelper.ExecuteDataset(cs, "ReadItemDetails", IDReceipt);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                yield return GetItemDetailsFromDataRow(row);
            }
        }

        private static ItemDetails GetItemDetailsFromDataRow(DataRow row)
        {
            return new ItemDetails
            {
                IDItem = (int)row["IDStavka"],
                Amount = (int)row["Kolicina"],
                PricePerPiece = (int)row["CijenaPoKomadu"],
                Dicount = (int)row["PopustUPostocima"],
                TotalPrice = (int)row["UkupnaCijena"],
                Product = row["Produkt"] != DBNull.Value ? row["Produkt"].ToString() : string.Empty,
                NumberOfProducts = row["BrojProizvoda"].ToString(),
                Color = row["Boja"].ToString(),
                MinimalAmountInStock = (int)row["MinimalnaKolicinaNaSkladistu"],
                PriceWithoutPDV = (int)row["CijenaBezPDV"],
                Subcategory = row["Potkategorija"].ToString(),
                Category = row["Kategorija"].ToString()
            };
        }

        //Product --------------------------------------------------- 
        public static Product GetProduct(int IDProduct)
        {
            DataRow row = SqlHelper.ExecuteDataset(cs, "ReadProduct", IDProduct).Tables[0].Rows[0];
            return GetProductFromDataRow(row);
        }
        public static IEnumerable<Product> GetAllProducts()
        {
            ds = SqlHelper.ExecuteDataset(cs, "ReadAllProducts");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                yield return GetProductFromDataRow(row);
            }
        }
        private static Product GetProductFromDataRow(DataRow row)
        {
            return new Product
            {
                IDProduct = (int)row["IDProizvod"],
                SubcategoryID = row["PotkategorijaID"] != DBNull.Value ? (int)row["PotkategorijaID"] : 0,
                Subcategory = row["Potkategorija"] != DBNull.Value ? row["Potkategorija"].ToString() : string.Empty,
                Title = row["Naziv"].ToString(),
                NumberOfProducts = row["BrojProizvoda"].ToString(),
                Color = row["Boja"] != DBNull.Value ? row["Boja"].ToString() : "-",
                MinimalAmountInStock = (int)row["MinimalnaKolicinaNaSkladistu"],
                PriceWithoutPDV = (int)row["CijenaBezPDV"]
            };
        }

        public static int CreateProduct(Product product)
        => SqlHelper.ExecuteNonQuery(cs, "CreateProizvod", product.Title, product.NumberOfProducts, product.Color, product.MinimalAmountInStock, product.PriceWithoutPDV, product.Subcategory, product.IDProduct);
        public static int UpdateProduct(Product product)
        => SqlHelper.ExecuteNonQuery(cs, "UpdateProduct", product.Title, product.NumberOfProducts, product.Color, product.MinimalAmountInStock, product.PriceWithoutPDV, product.SubcategoryID, product.IDProduct);
        public static int DeleteProduct(int productID)
        => SqlHelper.ExecuteNonQuery(cs, "DeleteProizvod", productID);

        //Subcategory -----------------------------------------------
        public static IEnumerable<Subcategory> GetAllSubcategories()
        {
            ds = SqlHelper.ExecuteDataset(cs, "ReadSubcategories");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                yield return GetSubcategoryFromDataRow(row);
            }
        }

        public static Subcategory GetSubcategory(int IDSubcategory)
        {
            DataRow row = SqlHelper.ExecuteDataset(cs, "ReadSubcategory", IDSubcategory).Tables[0].Rows[0];
            return GetSubcategoryFromDataRow(row);
        }

        private static Subcategory GetSubcategoryFromDataRow(DataRow row)
        {
            return new Subcategory
            {
                ID = (int)row["IDPotkategorija"],
                Title = row["Naziv"].ToString(),
                Category = row["Kategorija"] != DBNull.Value ? row["Kategorija"].ToString() : string.Empty,
                CategoryID = (int)row["IDKategorija"]
            };
        }

        public static int CreateSubcategory(Subcategory subcategory) => SqlHelper.ExecuteNonQuery(cs, "CreatePotkategorija", subcategory.Title, subcategory.CategoryID, subcategory.ID);
        public static int UpdateSubcategory(Subcategory subcategory) => SqlHelper.ExecuteNonQuery(cs, "UpdateSubcategory", subcategory.Title, subcategory.CategoryID, subcategory.ID);
        public static int DeleteSubcategory(int subcategoryID) => SqlHelper.ExecuteNonQuery(cs, "DeletePotkategorija", subcategoryID);

        //Category -----------------------------------------------
        public static IEnumerable<Category> GetCategorys()
        {
            ds = SqlHelper.ExecuteDataset(cs, "ReadCategories");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                yield return GetCategoryFromDataRow(row);
            }
        }
        public static Category GetCategory(int IDClient)
        {
            DataRow row = SqlHelper.ExecuteDataset(cs, "ReadCategory", IDClient).Tables[0].Rows[0];
            return GetCategoryFromDataRow(row);
        }

        private static Category GetCategoryFromDataRow(DataRow row)
        {
            return new Category
            {
                ID = (int)row["IDKategorija"],
                Title = row["Naziv"].ToString()
            };
        }

        public static int CreateCategory(Category category) => SqlHelper.ExecuteNonQuery(cs, "CreateKategorija", category.Title, category.ID);
        public static int UpdateCategory(Category category) => SqlHelper.ExecuteNonQuery(cs, "UpdateCategory", category.Title, category.ID);
        public static int DeleteCategory(int categoryID) => SqlHelper.ExecuteNonQuery(cs, "DeleteKategorija", categoryID);

        //Commercialist-------------------------------------------
        public static Commercialist GetCommercialist(int IDReceipt)
        {
            DataRow row = SqlHelper.ExecuteDataset(cs, "ReadCommercialist", IDReceipt).Tables[0].Rows[0];
            return GetCommercialistFromDataRow(row);
        }

        private static Commercialist GetCommercialistFromDataRow(DataRow row)
        {
            return new Commercialist
            {
                ID = (int)row["IDKomercijalist"],
                FirstName = row["Ime"].ToString(),
                LastName = row["Prezime"].ToString(),
                FullTime = (bool)row["StalniZaposlenik"]
            };
        }

        public static int GetCommercialistCount(int IDReceipt)
        {
            return (int)SqlHelper.ExecuteScalar(cs, "CountCommercialists", IDReceipt);
        }

        //CreditCard----------------------------------------------
        public static CreditCard GetCreditCard(int IDReceipt)
        {
            DataRow row = SqlHelper.ExecuteDataset(cs, "ReadCreditCard", IDReceipt).Tables[0].Rows[0];
            return GetCreditCardFromDataRow(row);
        }

        private static CreditCard GetCreditCardFromDataRow(DataRow row)
        {
            return new CreditCard
            {
                ID = (int)row["IDKreditnaKartica"],
                Number = row["Broj"].ToString(),
                Type = row["Tip"].ToString(),
                ExpirationMonth = (int)row["IstekMjesec"],
                ExpirationYear = (int)row["IstekGodina"],
            };
        }

        public static int GetCrediCardCount(int IDReceipt)
        {
            return (int)SqlHelper.ExecuteScalar(cs, "CountCreditCards", IDReceipt);
        }
        //City----------------------------------------------------        
        public static List<City> GetCities(int IDCountry)
        {
            List<City> collection = new List<City>();

            ds = SqlHelper.ExecuteDataset(cs, "GetCountryCity", IDCountry);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                collection.Add(new City
                {
                    IDCity = (int)row["IDGrad"],
                    Name = row["Naziv"].ToString()
                });
            }
            return collection;
        }

        public static IEnumerable<Country> GetCountries()
        {
            ds = SqlHelper.ExecuteDataset(cs, "GetCountries");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                yield return new Country
                {
                    IDCountry = (int)row["IDDrzava"],
                    Name = row["Naziv"].ToString()
                };
            }
        }
        //Receipt-------------------------------------------------
        public static IEnumerable<Receipt> GetAllReceipts(int IDKupac)
        {
            ds = SqlHelper.ExecuteDataset(cs, "ReadReceipt", IDKupac);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                yield return GetReceiptFromDataRow(row);
            }
        }

        public static Receipt GetReceiptDetails(int IDReceipt)
        {
            DataRow row = SqlHelper.ExecuteDataset(cs, "ReadReceiptDetails", IDReceipt).Tables[0].Rows[0];
            return GetReceiptFromDataRow(row);
        }

        private static Receipt GetReceiptFromDataRow(DataRow row)
        {
            return new Receipt
            {
                ID = (int)row["IDRacun"],
                Date = row["DatumIzdavanja"].ToString(),
                Number = row["BrojRacuna"].ToString(),
                Comment = row["Komentar"] != DBNull.Value ? row["Komentar"].ToString() : "No comment",
                CardNumber = row["Broj"] != DBNull.Value ? row["Broj"].ToString() : "-",
                CommercialistName = row["PunoIme"] != DBNull.Value ? row["PunoIme"].ToString() : "Unknown",
                Price = row["Cijena"].ToString(),
                Product = row["Proizvod"] != DBNull.Value ? row["Proizvod"].ToString() : "Unknown",
                Subcategory = row["Potkategorija"] != DBNull.Value ? row["Potkategorija"].ToString() : "Unknown",
                Category = row["Kategorija"] != DBNull.Value ? row["Kategorija"].ToString() : "Unknown",
            };
        }
    }
}