namespace zad3{
    public class Account{
        private uint id;
        private uint year;
        
        public Account(uint id, uint year){
            this.id = id;
            this.year = year;
        }

        public uint GetId(){
            return this.id;
        }
        public uint GetYear(){
            return this.year;
        }
    }
}