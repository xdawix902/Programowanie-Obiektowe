namespace zad1{
    public class Account{
        private uint id;
        private uint year;

        public Account(){
            this.id = 1;
            this.year = 2025;
        }

        public uint GetId(){
            return this.id;
        }
        public uint GetYear(){
            return this.year;
        }
    }
}