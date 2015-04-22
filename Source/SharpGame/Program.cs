namespace GameFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            Actor Raketka = new Actor();
            ColoredText rakpaint= new ColoredText();
            
            Raketka.AddEntity(rakpaint);

            Scene scene = new Scene();
            scene.AddEntity(Raketka);

            Game game = new Game();
            game.TargetFPS = 60;
            game.Initialize();
            game.Run(scene);
        }
    }
}
