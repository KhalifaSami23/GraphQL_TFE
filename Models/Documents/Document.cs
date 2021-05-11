using System;
using System.IO;
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using System.Threading.Tasks;
using TFE_Khalifa_Sami_2021.Models;

namespace Backend_RentHouse_Khalifa_Sami.Model.Documents
{
    public class Document
    {
        private Word.Application _wordApp;

        private string fileName;
        private string fileDestPath = Directory.GetCurrentDirectory()+"\\DocumentsWord\\";
        private string filesTemplateLink = Directory.GetCurrentDirectory()+"\\DocumentsWord\\Templates\\";

        private Contract _contract;
        private TypeContract _type;
        public Document(Contract contract, TypeContract type)
        {
            _contract= contract;
            _type = type;

            fileName = contract.User.Name+"_"+contract.User.Surname+"_"+type+".docx";
            fileDestPath += fileName;
            filesTemplateLink += "TEMPLATE_"+type+".docx";
        }

        public string GetFileName()
        {
            return fileName;
        }

        public string GenerateDocument()
        {
            _wordApp = new Word.Application();
            Word.Document myWordDoc;

            if (File.Exists(filesTemplateLink))
            {
                myWordDoc = _wordApp.Documents.Open(filesTemplateLink, Missing.Value, false);
                myWordDoc.Activate();
                GetDocument();
            }
            else
            {
                throw new Exception("TEMPLATE not Found!");
            }
            
            myWordDoc.SaveAs(fileDestPath);
            myWordDoc.Close();
            _wordApp.Quit();
            return fileDestPath;
        }

        private void GetDocument()
        {
            //find and replace
            FindAndReplace( "<client_surname>", _contract.User.Surname);
            FindAndReplace( "<client_address>", _contract.User.Address);
            FindAndReplace( "<client_postalcode>", _contract.User.PostalCode);
            FindAndReplace( "<client_city>", _contract.User.City);
            FindAndReplace( "<property_id>", _contract.Property.IdProperty);
            FindAndReplace( "<property_address>", _contract.Property.Address);
            FindAndReplace( "<date>", DateTime.Now.ToShortDateString());

            switch (_type)
            {
                case TypeContract.BAIL:
                    GetBail();
                    break;
                
                case TypeContract.GARANT:
                    GetGrant();
                    break;

                case TypeContract.RESILIATION_ANTICIPE:
                    GetResilAnticipe();
                    break;

                case TypeContract.CONGE_BAIL:
                    GetCongebail();
                    break;

                default:
                    throw new Exception("Type not valid !");
            }
        }

        private void GetBail()
        {
            FindAndReplace("<contract_rentCost>", _contract.Property.RentCost);
            FindAndReplace("<contract_fixedCharges>", _contract.Property.FixedChargesCost);
            FindAndReplace("<begin_contract>", _contract.BeginContract);
            FindAndReplace("<end_contract>", _contract.EndContract);
            FindAndReplace("<signature_date>", _contract.SignatureDate);
        }
        
        private void GetGrant()
        {
            FindAndReplace("<contract_guaranteeAmount>", _contract.GuaranteeAmount);
        }

        private void GetResilAnticipe()
        {
            FindAndReplace("<contract_endDate>", _contract.EndContract);
        }

        private void GetCongebail()
        {
            FindAndReplace("<begin_contract>", _contract.BeginContract);
            FindAndReplace("<end_contract>", _contract.EndContract);
        }

        //Find and Replace Method
        private void FindAndReplace(string toFindText, object replaceWithText)
        {
            _wordApp.Selection.Find.Execute(
                 toFindText,
                true,
                true,
                false,
                false, 
                false,
                true,
                1,
                false,
                replaceWithText
            );
        }

    }
}