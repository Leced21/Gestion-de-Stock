namespace Polymorphisme
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Forme forme1 = new Cercle(5.0);
            Forme forme2 = new Rectangle(4.0, 6.0);

            forme1.CalculerAire(); // Appel à la méthode de Cercle
            forme2.CalculerAire(); // Appel à la méthode de Rectangle
        }
    }
    class Forme
    {
        public virtual void CalculerAire()
        {
            Console.WriteLine("Calcul de l'aire de la forme de base");
        }
    }
    class Cercle : Forme
    {
        private double rayon;

        public Cercle(double rayon)
        {
            this.rayon = rayon;
        }

        public override void CalculerAire()
        {
            double aire = Math.PI * rayon * rayon;
            Console.WriteLine("Aire du cercle : " + aire);
        }
    }

    class Rectangle : Forme
    {
        private double longueur;
        private double largeur;

        public Rectangle(double longueur, double largeur)
        {
            this.longueur = longueur;
            this.largeur = largeur;
        }

        public override void CalculerAire()
        {
            double aire = longueur * largeur;
            Console.WriteLine("Aire du rectangle : " + aire);
        }
    }
}