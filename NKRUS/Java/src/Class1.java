
import java.util.Arrays;

/**
 * Created by NKRUS on 24.04.14.
 */
public class Class1 {

    public static void main(String[] args) throws Exception{

        double[] nums = {2,7,9,4,15,1,8};
        double[] newnums = new double[7];


        System.out.println("----------- Элементы исходного массива -----------------");
        for (int i = 0; i<nums.length; ++i){
        System.out.print(" " + nums[i]);
        }

        newnums = CreateSortedArray(nums);
        System.out.println("----------- Элементы массива после сортировки методом CreateSortedArray -----------------");
        for (int i = 0; i<newnums.length; ++i){
            System.out.print(" " + newnums[i]);
        }

        Sort(nums);
        System.out.println("----------- Элементы массива после сортировки методом Sort -----------------");
        for (int i = 0; i<nums.length; ++i){
            System.out.print(" " + nums[i]);
        }


    }

    static void Sort(double[] a){

        for (int i = 0; i < a.length; i++)
        {
            for (int j = i + 1; j < a.length; j++)
            {
                if (a[i] > a[j])
                {
                    double temp = a[i];
                    a[i] = a[j];
                    a[j] = temp;
                }
            }
        }

    }


    static  double[] CreateSortedArray(double[] a){
        double[] newnums = new double[a.length];
        for (int i = 0; i < a.length; i++){
            newnums[i] = a[i];
        }

        Sort(newnums);

        return newnums;
    }
}
