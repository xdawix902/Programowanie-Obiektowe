namespace Drugie{
    public class User{
        private int id;

        public void ResetId(){
            this.id = 1;
            return;
        }
        public int GetId(){
            return this.id;
        }
    }
}