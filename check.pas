unit check;

interface

uses crt;
var keys:char;
procedure askforend;

implementation
procedure askforend;
begin
clrscr;
writeln('._____________________________________________________________.');
writeln('|                      Are you sure?                          |');
writeln('|_____________________________________________________________|');
writeln('|               Press "1" for return to menu                  |');
writeln('|_____________________________________________________________|');
writeln('|                     Press "2" for exit                      |');
writeln('|_____________________________________________________________|');
repeat keys:=readkey;
until (keys = '1') or (keys = '2' );
if keys = '2' then halt;
end;
end.