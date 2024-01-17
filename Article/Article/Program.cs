using System;
using System.IO;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;

namespace Gestion_de_stock
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Entrez le libelé de votre article");
            string Name = Console.ReadLine();
            Console.WriteLine("Entrez son prix en Euro");
            float sale_Price = float.Parse(Console.ReadLine());
            Console.WriteLine("Entrez sa quantité en stock");
            int Qt_stock = int.Parse(Console.ReadLine());

            Article monarticle = new  Article (1,Name, sale_Price, Qt_stock);
            monarticle.EnregistrerArticle();
            //monarticle.RechercherparRef("59");
            //monarticle.RechercherparNom("Bis");
            //monarticle.ModifierArticle("59", "arachide", 25, 8);
            ///monarticle.SupprimerArticle("23");
            //monarticle.RechercherparInterPrice(2, 200);
            monarticle.AfficherArticle();
        }
    }

    // Defintion de la classe Article
    public class Article
    {
        private int Num_ref;
        private string Name;
        private float SalePrice;
        private int Qt_stock;


        // Definition des accesseur et mutateur

        public int num_ref
        {
            get { return Num_ref; }
            set { Num_ref = value; }
        }
        public string name
        {
            get { return Name; }
            set { Name = value; }
        }
        public float saleprice
        {
            get { return SalePrice; }
            set { SalePrice = value; }
        }
        public int qt_stock
        {
            get { return Qt_stock; }
            set { Qt_stock = value; }
        }

        // Definition du constructeur

        public Article(int Num_ref, string Name, float SalePrice, int Qt_stock)
        {
            Random random = new Random();
            this.Num_ref = random.Next(1, 10000001);
            this.Name = Name;
            this.SalePrice = SalePrice;
            this.Qt_stock = Qt_stock;
        }

        // Methode ToString()

        public override string ToString()
        {
            return $"Num_ref : {Num_ref}, Name : {Name}, SalePrice: {SalePrice}, Qt_stock: {Qt_stock}";
        }

        public void EnregistrerArticle()
        {
            try
            {
                using (StreamWriter SW = new StreamWriter(@"C:/Users/cedri/Desktop/OldApp/EXERCICES C#/Gestion d'un stock/Article.txt", true))
                {
                    SW.WriteLine("*" + Num_ref + "#" + Name + "&" + SalePrice + "@" + Qt_stock +"!");
                    Console.WriteLine("l'article a été créé");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Le dossier n'existe pas." + e.Message);
            }

        }
        public void RechercherparRef(string refe)
        {
            try
            {
                bool articleTrouve = false;
                using (StreamReader SW = new StreamReader(@"C:/Users/cedri/Desktop/OldApp/EXERCICES C#/Gestion d'un stock/Article.txt", true))
                {
             
                    foreach (string lines in File.ReadLines(@"C:/Users/cedri/Desktop/OldApp/EXERCICES C#/Gestion d'un stock/Article.txt"))
                    {
                        int start = lines.IndexOf("*");
                        int end = lines.IndexOf("#");
                        if (start != -1 && end != -1)
                        {
                            string subString = lines.Substring(start + 1, end - start - 1);
                            if (subString == refe)
                            {
                                Console.WriteLine("L'article existe");
                                articleTrouve = true;
                                break;
                            }
                        }
                    }

                }
                if (!articleTrouve)
                {
                    Console.WriteLine("L'article n'existe pas");
                }

            }

            catch (Exception e)
            {

                Console.WriteLine("Le dossier n'existe pas."+e.Message);


            }
        }
        public void RechercherparNom(string nom)
        {
            try
            {
                using (StreamReader SW = new StreamReader(@"C:/Users/cedri/Desktop/OldApp/EXERCICES C#/Gestion d'un stock/Article.txt", true))
                {

                    foreach (string lines in File.ReadLines(@"C:/Users/cedri/Desktop/OldApp/EXERCICES C#/Gestion d'un stock/Article.txt"))
                    {
                        int start = lines.IndexOf("#");
                        int end = lines.IndexOf("&");
                        if (start != -1 && end != -1)
                        {
                            string subString = lines.Substring(start + 1, end - start - 1);
                            if (subString == nom)
                            {
                                Console.WriteLine("l'article existe");
                            }
                        }
                    }
                }

            }

            catch (Exception e)
            {

                Console.WriteLine("Le dossier n'existe pas."+e.Message);


            }
        }

        public void RechercherparInterPrice(float minPrice, float maxPrice)
        {
            try
            {
                bool articleTrouve = false;
                using (StreamReader SW = new StreamReader(@"C:/Users/cedri/Desktop/OldApp/EXERCICES C#/Gestion d'un stock/Article.txt", true))
                {

                    foreach (string lines in File.ReadLines(@"C:/Users/cedri/Desktop/OldApp/EXERCICES C#/Gestion d'un stock/Article.txt"))
                    {
                        int start = lines.IndexOf("&");
                        int end = lines.IndexOf("@");
                        if (start != -1 && end != -1)
                        {
                            string subString = lines.Substring(start + 1, end - start - 1);
                            double isubString=Convert.ToDouble(subString);
                            if (isubString > minPrice && isubString <maxPrice)
                            {
                                Console.WriteLine(lines);
                                articleTrouve = true;
                                
                            }
                        }
                    }

                }
                if (!articleTrouve)
                {
                    Console.WriteLine("L'article n'existe pas");
                }

            }

            catch (Exception e)
            {

                Console.WriteLine("Le dossier n'existe pas." + e.Message);


            }
        }

        public void ModifierArticle(string search_string, string Name, float SalePrice, int Qt_stock)
        {
            try
            {
                using (StreamReader SW = new StreamReader(@"C:/Users/cedri/Desktop/OldApp/EXERCICES C#/Gestion d'un stock/Article.txt", true))
                using (StreamWriter temp = new StreamWriter(@"C:/Users/cedri/Desktop/OldApp/EXERCICES C#/Gestion d'un stock/temp.txt", true))
                {
                    //List<string> modifications = new List<string>();
                    foreach (string lines in File.ReadLines(@"C:/Users/cedri/Desktop/OldApp/EXERCICES C#/Gestion d'un stock/Article.txt"))
                    {
                        int start = lines.IndexOf("*");
                        int end = lines.IndexOf("#");
                        if (start != -1 && end != -1)
                        {
                            string subString = lines.Substring(start + 1, end - start - 1);
                            if (subString == search_string)
                            {
                                temp.WriteLine("*" + search_string + "#" + Name + "&" + SalePrice + "@" + Qt_stock + "!");
                                
                            }
                            else
                            {
                                temp.WriteLine(lines);
                            }
                        }
                    }
                }
                // Remplacer le fichier d'origine par le fichier temporaire
                File.Delete(@"C:/Users/cedri/Desktop/OldApp/EXERCICES C#/Gestion d'un stock/Article.txt");
                File.Move(@"C:/Users/cedri/Desktop/OldApp/EXERCICES C#/Gestion d'un stock/temp.txt", @"C:/Users/cedri/Desktop/OldApp/EXERCICES C#/Gestion d'un stock/Article.txt");
                Console.WriteLine("l'article a été modifié avec succès");
            }
            
            catch (Exception e)
            {
                Console.WriteLine("Une erreur s'est produite : " + e.Message);
            }
        }

        public void SupprimerArticle(string search_string)
        {
            try
            {
                using (StreamReader SW = new StreamReader(@"C:/Users/cedri/Desktop/OldApp/EXERCICES C#/Gestion d'un stock/Article.txt", true))
                using (StreamWriter temp = new StreamWriter(@"C:/Users/cedri/Desktop/OldApp/EXERCICES C#/Gestion d'un stock/temp.txt", true))
                {
                    //List<string> modifications = new List<string>();
                    foreach (string lines in File.ReadLines(@"C:/Users/cedri/Desktop/OldApp/EXERCICES C#/Gestion d'un stock/Article.txt"))
                    {
                        int start = lines.IndexOf("*");
                        int end = lines.IndexOf("#");
                        if (start != -1 && end != -1)
                        {
                            string subString = lines.Substring(start + 1, end - start - 1);
                            if (subString == search_string)
                            {
                                continue;   
                            }
                            else
                            {
                                temp.WriteLine(lines);
                            }
                
                        }
                    }
                }
                // Remplacer le fichier d'origine par le fichier temporaire
                File.Delete(@"C:/Users/cedri/Desktop/OldApp/EXERCICES C#/Gestion d'un stock/Article.txt");
                File.Move(@"C:/Users/cedri/Desktop/OldApp/EXERCICES C#/Gestion d'un stock/temp.txt", @"C:/Users/cedri/Desktop/OldApp/EXERCICES C#/Gestion d'un stock/Article.txt");
                Console.WriteLine("l'article a été supprimé avec succès");
            }


            catch (Exception e)
            {
                Console.WriteLine("Une erreur s'est produite : " + e.Message);
            }
        }

        public void AfficherArticle()
        {
            using (StreamReader SW = new StreamReader(@"C:/Users/cedri/Desktop/OldApp/EXERCICES C#/Gestion d'un stock/Article.txt", true))
            {
                foreach (string lines in File.ReadLines(@"C:/Users/cedri/Desktop/OldApp/EXERCICES C#/Gestion d'un stock/Article.txt"))
                {
                    int start = lines.IndexOf("*");
                    int end = lines.IndexOf("#");
                    int start2 = lines.IndexOf("#");
                    int end2 = lines.IndexOf("&");
                    int start3 = lines.IndexOf("&");
                    int end3 = lines.IndexOf("@");
                    int start4 = lines.IndexOf("@");
                    int end4 = lines.IndexOf("!");

                    string subString = lines.Substring(start + 1, end - start - 1);
                    string subString2 = lines.Substring(start2 + 1, end2 - start2 - 1);
                    string subString3 = lines.Substring(start3 + 1, end3 - start3 - 1);
                    string subString4 = lines.Substring(start4 + 1, end4 - start4 - 1);
                    Console.WriteLine(subString +" "+ subString2 +" "+ subString3+ " "+subString4);
                }
            }
        }
    }

}