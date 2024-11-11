class Program {
    static void Main(string[] args) {
        int[][] jaggedArray = new int[2][];
        jaggedArray[0] = new int[2] { 1, 2 };
        jaggedArray[1] = new int[3] { 3, 4, 5 };

        Console.WriteLine(jaggedArray[1][2]); // 1
    }
}