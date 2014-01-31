program task_1;{Нахождение суммы бесконечного числового ряда}

uses
  crt;

var
  x: real;
  n: longint;
  summ: real; {искомая сумма}
  diff: real; {разность суммы и точного значения}
  Eps: real;  {точность}
  fact: longint; {факториал 2n}
  i: integer;

begin
   {Ввод необходимых данных}
  write('Введите х:');
  readln(x);
  write('Введите точность:');
  readln(Eps);
   {Вычисление суммы ряда (цикл с постусловием)}
  if (Eps > 1) or (Eps < 0) then
  begin
    writeln('Точность не должна быть больше единицы и отрицательной');
    exit;   
  end;
  n := -1;
  repeat
    n := n + 1;
      {нахождение факториала}
    fact := 1;
    for i := 2 to 2 * n do fact := fact * i;
      {Нахождение суммы}
    summ := summ + (Power((-1), n) * (Power(x, (2 * n)) / fact) );
    diff := abs(cos(x) - summ);
  until diff < Eps;
   (*Выводим результаты*)
  writeln('Было просуммированно элементов: ', n + 1);
  writeln('Найденная сумма ряда: ', summ);
  writeln('Точное значение: ', cos(x));
  writeln('Разность суммы и точного значение: ', diff);
end.
