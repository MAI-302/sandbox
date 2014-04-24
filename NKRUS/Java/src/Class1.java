import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.util.Arrays;

/**
 * Created by NKRUS on 24.04.14.
 */
public class Class1 {
    static double[] newnums = new double[7];
    static double[] nums = {2,7,9,4,15,1,8};
    public static void main(String[] args) throws Exception{
        //инициализируем массивы


        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in)); // объект для чтения входных данных

        System.out.println("----------- Элементы исходного массива -----------------");
        System.out.println(Arrays.toString(nums)); //выводим массив
        System.out.println("----------- Элементы массива после сортировки методом CreateSortedArray -----------------");
        System.out.println(Arrays.toString(CreateSortedArray(nums))); //выводим массив
        System.out.println("----------- Элементы массива после сортировки методом Sort -----------------");
        Sort(nums);
        System.out.println(Arrays.toString(nums)); //выводим массив

    }

    static void Sort(double[] a){
        Arrays.sort(a);
    }

    static  double[] CreateSortedArray(double[] a){
        System.arraycopy(nums, 0, a, 0, nums.length);
        Arrays.sort(a);
        return a;
    }
}
