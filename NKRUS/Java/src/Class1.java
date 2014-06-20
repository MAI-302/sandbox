
import java.util.Arrays;

/**
 * Created by NKRUS on 24.04.14.
 */
public class Class1 {

    public static void main(String[] args) throws Exception {

        double[] nums = {2, 7, 9, 4, 15, 1, 8};
        double[] newnums = new double[7];


        System.out.println("----------- Элементы исходного массива -----------------");
        PrintScreen(nums);

        newnums = CreateSortedArray(nums);
        System.out.println("----------- Элементы массива после сортировки методом CreateSortedArray -----------------");
        PrintScreen(newnums);

        Sort(nums);
        System.out.println("----------- Элементы массива после сортировки методом Sort -----------------");
        PrintScreen(nums);



    }

    private static void Sort(double[] a) {

        for (int i = 0; i < a.length; i++) {
            for (int j = i + 1; j < a.length; j++) {
                if (a[i] > a[j]) {
                    double temp = a[i];
                    a[i] = a[j];
                    a[j] = temp;
                }
            }
        }

    }


    private static double[] CreateSortedArray(double[] a) {
        double[] newnums = new double[a.length];
        for (int i = 0; i < a.length; i++) {
            newnums[i] = a[i];
        }
        Sort(newnums);
        return newnums;
    }

    private static void PrintScreen(double[] a){
        for (int i = 0; i < a.length; ++i) {
            System.out.print(" " + a[i]);

    }
    }
}
