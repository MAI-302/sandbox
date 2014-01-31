#include <stdio.h>//подключение библиотек
#include <math.h>

double X(int m,int k);
double Y(double x,double *a,double EPS);
double Z(double y,double *a,double EPS);
void Printing(int m,int k,double x,double Y,double Z);

int main(){
	int k=30;//вводим счётчик
	int m=3;//переменная для запоминания начального значения k
	double a;
	double x,y,z;// ввод переменных
	const double EPS=0.00000001;
	x=X(m,k);
	y=Y(x,&a,EPS);
	z=Z(y,&a,EPS);
	Printing(m,k,x,y,z);
}


double X(int m,int k){//
	double proizv=1;
	if (m>k){
		printf("neverno zadano k dlya 1-ogo yravneiya");
	}
	while (m<=k){
		proizv*=(log(m)+m*m);
		++m;
	}
	return proizv;
}
double Y(double x,double *a,double EPS){//
	double y;
	do {
		printf("vvedite chislo a\n");
	}
	while (scanf("%lf",a)!=1);
	y=sqrt(x)-*a+x;
	if(fabs(y)<EPS){//abs или fabs???
		printf("error counting Y in denominator");
		return -1;//не помню как выводит return.возможно нужен exit
	}
	y=(pow(sin(pow(x,3)),2)+*a)/(sqrt(x)-*a+x);
	return y;
}
double Z(double y,double *a,double EPS){// вставить *а
	if (*a<0){
		printf("error counting Z");
		return -1;
	}
	if (fabs(y-*a)<EPS){
		if (y<0){
			printf("error counting Z");
		}
		return (log(y)-sqrt(*a));
	}
	else{
		return(sqrt(*a)+pow(tan(y),2));
	}
}
void Printing(int m,int k,double x,double y,double z){
	printf("k na4alnoe =%d\nk kone4noe =%d\n",m,k);
	printf("x=%lf\ny=%lf\nz=%lf",x,y,z);
}