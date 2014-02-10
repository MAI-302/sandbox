program Project6;
var
    k:integer;
    a,b,e,l,v,u:real;
function f(x:real):real;
    begin
        f:=-5/(x*x-1);
     end;
begin
      writeln('enter a - start of the interval of uncertainty');
          readln(a);
     writeln('enter b - end of the interval of uncertainty');
          readln(b);
     writeln('enter e - the constant distinctiveness');
          readln(e);
     writeln('enter l - permissible range of uncertainty');
          readln(l);
if (e < 0) or (l < 0) then
      begin
            writeln('error : e or l < 0');
             halt;
        end;
if (e>l/2)then
   begin
         writeln('Incorrect e input');
         readln;
          exit;
    end;
k:=1;
   
    if b-a<l then
    writeln('Solution is found')
	
      else 
		begin
			  writeln(' k|____a_____|____b_____|____v_____|____u_____|____fv____|___fu_____');
              while (b-a) > l do
	   begin
	       v:=(a+b)/2-e ;
	       u:=(a+b)/2+e ;

	          if f(v) > f(u) then
	  	a:=v

	  else
	  	b:=u;

	  writeln(k:2,'|',a:10:6,'|',b:10:6,'|',v:10:6,'|',u:10:6,'|',f(v):10:6,'|',f(u):10:6);
	  k:=k+1;
  	if k > 100 then
	  	begin
		  	writeln('too many iterations');
			  exit;
  		end;
	  end;
  end;
writeln('the number of iterations=',k-1);
writeln(f((a+b)/2):10:6,' = the optimal value function,where argument = ',(a+b)/2:10:6);
if k=1 then
writeln('function was considered  1 time')
else 
writeln ('function was considered ',2*(k-1)+1,' times');
readln;
end.
