namespace GenericsBuilder
{
    class Students {
        private string[] names = new string[3]{ "Jack", "Joe", "Julie" };
        private int[] age = new int[3] { 22, 25, 23 };

        public Student this[int i] => new Student { Age = age[i], Name = names[i] };
    }



}
