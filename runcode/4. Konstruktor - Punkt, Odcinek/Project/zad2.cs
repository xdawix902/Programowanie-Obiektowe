namespace zad2{
    public class Point{
        private double X;
        private double Y;

        public Point(double X, double Y){
            this.X = X;
            this.Y = Y;
        }

        public Point(Point other){
            this.X = other.X;
            this.Y = other.Y;
        }

        public string GetPointInfo(){
            return $"{this.X} {this.Y}";
        }
    }

    public class Segment{
        private Point P1;
        private Point P2;

        public Segment(Point P1, Point P2){
            this.P1 = P1;
            this.P2 = P2;
        }

        public Segment(Segment other){
            this.P1 = new Point(other.P1);
            this.P2 = new Point(other.P2);
        }
    }
}