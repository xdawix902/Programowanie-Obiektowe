namespace RunCode{

    public class User{
        private int age;
        private string name;

        public User(string name){
            this.name = name;
            this.age = 5;
        }

        public string GetName(){
            return this.name;
        }

        public int GetAge(){
            return this.age;
        }

    }
}