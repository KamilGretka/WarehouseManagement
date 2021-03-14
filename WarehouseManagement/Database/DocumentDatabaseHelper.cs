using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using WarehouseManagement.Logic;
using WarehouseManagement.Models.Database;
using WarehouseManagement.Models.DTO;
using WarehouseManagement.Models.Logger;
using WarehouseManagement.ViewModels;

namespace WarehouseManagement.Database
{
    internal static class DocumentDatabaseHelper
    {
        internal static DocumentHeader GetDocumentsById(Guid id)
        {
            try
            {
                using (AppDBContext db = new AppDBContext())
                {
                    return db.DocumentHeader.FirstOrDefault(x => x.ID == id);
                }
            }
            catch (Exception ex)
            {
                FileLogger.AddLogExceptionToFile(ex.Message);
            }

            return new DocumentHeader();
        }

        internal static IList<Product> GetProductsByDocumentId(Guid id)
        {
            try
            {
                using (AppDBContext db = new AppDBContext())
                {
                    return db.Product.Where(x => x.DocumentId == id).ToList();
                }
            }
            catch (Exception ex)
            {
                FileLogger.AddLogExceptionToFile(ex.Message);
            }

            return new List<Product>();
        }

        internal static IList<DocumentHeader> GetDocumentsByClientNumber(int clientNumber)
        {
            try
            {
                using (AppDBContext db = new AppDBContext())
                {
                    return db.DocumentHeader.Where(x => x.ClientNumber == clientNumber).ToList();
                }
            }
            catch (Exception ex)
            {
                FileLogger.AddLogExceptionToFile(ex.Message);
            }

            return new List<DocumentHeader>();
        }

        internal static void AddDocuments(DocumentViewModel documentViewModel)
        {
            List<Product> localProducts = new List<Product>();

            DocumentHeader documentHeader = new DocumentHeader()
            {
                ID = Guid.NewGuid(),
                ClientName = documentViewModel.ClientNameViewInput,
                Date = documentViewModel.Date == DateTime.MinValue ? DateTime.Now : documentViewModel.Date,
                ClientNumber = documentViewModel.ClientNumberViewInput 
            };

            for (int i = 0; i < documentViewModel.ProductsDataGrid.Items.Count; i++)
            {
                var productItem = (Product)documentViewModel.ProductsDataGrid.Items.GetItemAt(i);

                localProducts.Add(new Product
                {
                    Name = productItem.Name,
                    ID = Guid.NewGuid(),
                    DocumentId = documentHeader.ID,
                    Amount = productItem.Amount,
                    GrossPrice = productItem.GrossPrice,
                    NetPrice = productItem.NetPrice,
                });
            }

            documentHeader.GrossPrice = localProducts.Select(x => x.GrossPrice).Sum();
            documentHeader.NetPrice = localProducts.Select(x => x.NetPrice).Sum();

            try
            {
                using (AppDBContext db = new AppDBContext())
                {
                    db.DocumentHeader.Add(documentHeader);
                    db.Product.AddRange(localProducts);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FileLogger.AddLogExceptionToFile(ex.Message);
            }
        }

        internal static void UpdateDocumentById(Guid id, DocumentHeader newDocumentHeader)
        {
            try
            {
                using (AppDBContext db = new AppDBContext())
                {
                    var existingDocumentHeader = db.DocumentHeader.FirstOrDefault(x => x.ID == id);

                    if (!string.IsNullOrEmpty(newDocumentHeader.ClientName))
                    {
                        existingDocumentHeader.ClientName = newDocumentHeader.ClientName;
                        db.Logs.Add(PrepareDbLog($"Change {nameof(newDocumentHeader.ClientName)} from {existingDocumentHeader.ClientName} to {newDocumentHeader.ClientName}"));
                    }

                    if (newDocumentHeader.Date == DateTime.MinValue)
                    {
                        existingDocumentHeader.Date = newDocumentHeader.Date;
                        db.Logs.Add(PrepareDbLog($"Change {nameof(newDocumentHeader.Date)} from {existingDocumentHeader.Date} to {newDocumentHeader.Date}"));
                    }

                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FileLogger.AddLogExceptionToFile(ex.Message);
            }
        }

        internal static void RemoveDocumentById(Guid id)
        {
            try
            {
                using (AppDBContext db = new AppDBContext())
                {
                    db.DocumentHeader.Remove(db.DocumentHeader.FirstOrDefault(x => x.ID == id));
                    db.SaveChanges();
                    MessageBox.Show("Record from database has been deleted.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                FileLogger.AddLogExceptionToFile(ex.Message);
            }
        }

        private static Log PrepareDbLog(string message)
        {
            return new Log
            {
                ID = Guid.NewGuid(),
                Date = DateTime.Now,
                Message = message
            };
        }
    }
}
