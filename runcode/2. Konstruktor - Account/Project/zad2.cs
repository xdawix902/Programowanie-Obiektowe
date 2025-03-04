namespace zad2{
    public class Account{
        private uint id;
        private uint year;
        
        public Account(uint id){
            this.id = id;
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