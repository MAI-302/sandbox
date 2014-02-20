unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Unit2, Unit3, Menus,Registry;

type
    Tcity = record //запись "город"
      name: string[50]; //поле название Город
   citizens: string[50]; //поле Жители
       country: string[50]; //поле Страна
            end;

  TForm1 = class(TForm)
    lbl1: TLabel;   //Компоненты Label
    lbl2: TLabel;
    lbl3: TLabel;
    edt1: TEdit;  //Компоненты Edit
    edt2: TEdit;
    edt3: TEdit;
    btn1: TButton;  // Кнопка 'Занести'
    mm1: TMainMenu;  // Компонент MainMenu
    df1: TMenuItem;  // Заголовок главного меню 'Файл'
    N1: TMenuItem;   // Файл->Новый
    N2: TMenuItem;   // Файл->Открыть
    N4: TMenuItem;   // Файл->Сохранить как
    N6: TMenuItem;   // Сведения
    dlgOpen1: TOpenDialog;   //Диалог открытия файла
    dlgSave1: TSaveDialog;   // Диалог сохранения файла
    N3: TMenuItem;   // Переключатель на файл стран
    N5: TMenuItem;   // Выход
    procedure btn1Click(Sender: TObject);  //При нажатии на кнопку 'Занести'
    procedure N1Click(Sender: TObject);    // Создание нового файла городов
    procedure N6Click(Sender: TObject);    // Открывает Сведения
    procedure N2Click(Sender: TObject);    // Открыть файл городов
    procedure N4Click(Sender: TObject);    // Сохраняет файл городов
    procedure N3Click(Sender: TObject);    // Переключает на файл стран
    procedure N5Click(Sender: TObject);    // Закрывает программу
    procedure edt1KeyPress(Sender: TObject; var Key: Char); // Процедуры для нажатия клавиши Enter
    procedure edt2KeyPress(Sender: TObject; var Key: Char);
    procedure edt3KeyPress(Sender: TObject; var Key: Char);
    procedure FormCreate(Sender: TObject);  //Оповещение о существовании файлов перед запуском программы

  private
    { Private declarations }
  public
    { Public declarations }
  end;


  var
               R: TRegistry; //переменная для работы с реестром
           Form1: TForm1;  //форма файла городов
               i: Integer;   //цикловая переменная
        way_city: ShortString; //путь к файлу городов
        way_country: ShortString; //путь к фалу стран
             buf: Tcity; //временная переменная типа Tcity
              FP: file of Tcity;  //файловая переменная типа Tcity
  buttonSelected: Integer; //переменная кнопки подтверждения

implementation

{$R *.dfm}

function nalcif(s:string): Boolean; //функция проверки на цифры, если есть, то возвращает true
begin
  Result:= false;
  for i:=1 to length(s) do
  if (s[i] in ['0'..'9'])
  then begin Result:= True; Break; end; //проверяем всю строку на наличие цифр, если находим, то результат true. break - выход из цикла
end;

procedure TForm1.btn1Click(Sender: TObject); //кнопка "занести"
begin
if way_city <> '' then
begin
  if (edt1.Text<>'') and (edt3.Text<>'') then //проверка заполнения всех полей
    begin
      if not nalcif(edt1.Text) and not nalcif(edt3.Text) then  //проверка на отсутствие  цифр
       begin
        Assignfile(FP,way_city); //связываем перем-ю FP с файлом городов
        Reset(FP); //открытие файла городов
        i:=FileSize(FP); //присваиваем переменной i значение количества эл-ов FP
        buf.name:=edt1.Text;      //считываем поле "город" \
        buf.citizens:=edt2.Text; //считываем поле "жители"  |--> в buf(буфер)
        buf.country:=edt3.Text;       //считываем поле "страна" /
        Seek(FP,i); //перемещаем указ-ль в позицию i (в файле связ-ым с файловой перем-ой FP)
        write(FP,buf); //запис-ем перем-ю buf в файл (связ-й с файловой перем-й FP)
        CloseFile(FP); //закрываем файл FP

        //очищаем поля
	    	edt1.Text:='';
        edt2.Text:='';
        edt3.Text:='';
        edt1.SetFocus; //Установить фокус на первый Edit
       end
      else ShowMessage('поля ''Название города'' и ''Название страны'' не должны содержать цифр');
    end
  else ShowMessage('заполните поля "Название города" и "Название страны"'); //выводится сообщение, в случае не заполнения всех полей
end else ShowMessage('Не найден путь к файлу Городов.'+#13+'Создайте новый, или Откройте файл Городов');
end;

 procedure TForm1.N1Click(Sender: TObject); //меню файл-->новый
begin 
  dlgSave1:= TSaveDialog.Create(self); //создание диалога
  dlgSave1.Title:='создать новый файл городов'; // заголовок нашего диалога
  dlgSave1.Filter:='*.cit|*.cit';  // Разрешаем создать файл типа *.cit
  dlgSave1.DefaultExt:='cit'; // задает расширение, автоматически используемое в имени файла, если пользователь не указал расширение
  dlgsave1.Execute; // Показ диалога открытия файла  
  if FileExists(dlgSave1.FileName) then  //если данный файл существует  (FileExists возвращает значение true если файл существует )
     begin
      buttonSelected:= MessageDlg('вы действительно хотите перезаписать файл '+dlgSave1.FileName, mtWarning, mbOKCancel, 0);
      if buttonSelected = mrYes then begin AssignFile(FP,dlgSave1.FileName); Rewrite(FP); end; //перезаписываем файл, если нажата кнопка ок
      if buttonSelected = mrCancel then dlgSave1.FileName:=''; // нажав на cancel опустошаем переменную dlgSave1.FileName
     end
  else begin  AssignFile(FP,dlgSave1.FileName); Rewrite(FP); end; //создаем файл, если файл отсутствует
  
  //если есть новый путь к файлу городов, то заносим его в системный файл
  if (dlgSave1.FileName<>'') then
   begin // записываем в реестр новый путь в файлу городов
    way_city := dlgSave1.FileName;
    R := TRegistry.Create;  // создаем объект TRegistry
    R.OpenKey('software\MyProg',True); // открываем и создаем ключ, True - если нет такого ключа то создать его
    R.WriteString('way_city',way_city); // записываем путь к файлу городов
    R.CloseKey; // закрываем ключ
    R.Free;  // освобождаем ключ
   end;

  dlgSave1.Free;  //освобождение диалога
end;

 procedure TForm1.N2Click(Sender: TObject); //меню файл-->открыть
begin
  dlgOpen1:=TOpenDialog.Create(Self);  //создание диалога
  dlgOpen1.Title:='создать файл городов'; // заголовок нашего диалога
  dlgOpen1.Filter:='*.cit|*.cit';  // Разрешаем создать файл типа *.cit
  dlgOpen1.DefaultExt:='cit'; // задает расширение, автоматически используемое в имени файла, если пользователь не указал расширение
  dlgOpen1.Execute; // Показ диалога открытия файла
  if FileExists(dlgOpen1.FileName) then  //если данный файл существует  (FileExists возвращает значение true если файл существует )
   begin
    way_city := dlgOpen1.FileName;
    R := TRegistry.Create;   // создаем объект TRegistry
    R.OpenKey('software\MyProg',True); // открываем и создаем ключ, True - если нет такого ключа то создать его
    R.WriteString('way_city',way_city);  // записываем путь к файлу городов
    R.CloseKey;  // закрываем ключ
    R.Free;   // освобождаем ключ
   end;
  dlgOpen1.Free;  //освобождение диалога
end;

 procedure TForm1.N4Click(Sender: TObject); //меню файл-->сохранить как...
 begin
  dlgSave1:= TSaveDialog.Create(self); //создание диалога
  dlgSave1.Title:='сохранить как...'; // заголовок нашего диалога
  dlgSave1.Filter:='*.cit|*.cit';  // Разрешаем создать файл типа *.cit
  dlgSave1.DefaultExt:='cit'; // задает расширение, автоматически используемое в имени файла, если пользователь не указал расширение
  dlgsave1.Execute;  // Показ диалога открытия файла
  if FileExists(dlgSave1.FileName) then  //если данный файл существует  (FileExists возвращает значение ture если файл существует )
     begin
      buttonSelected:= MessageDlg('вы действительно хотите перезаписать файл '+dlgSave1.FileName, mtWarning, mbOKCancel, 0);
      if buttonSelected = mrYes then //перезаписываем файл, если нажата кнопка ок
         CopyFile(Pchar(way_city + #0), Pchar(dlgSave1.FileName + #0), false); //копируем файл в новое место(false параметр для перезаписи уже имеющегося файла)
      if buttonSelected = mrCancel then dlgSave1.FileName:=''; // нажав на cancel опустошаем переменную dlgSave1.FileName
     end
  else CopyFile(Pchar(way_city + #0), Pchar(dlgSave1.FileName + #0), false); //создаем файл, если файл отсутствует
  //если есть новый путь к файлу городов, то заносим его в реестр
  if (dlgSave1.FileName<>'') then
   begin
    way_city := dlgSave1.FileName;
    R := TRegistry.Create;  // создаем объект TRegistry
    R.OpenKey('software\MyProg',True);  // открываем и создаем ключ, True - если нет такого ключа то создать его
    R.WriteString('way_city',way_city); // записываем путь к файлу городов
    R.CloseKey;  // закрываем ключ
    R.Free;   // освобождаем ключ
   end;

  dlgSave1.Free;  //Освобождение диалога
 end;

 procedure TForm1.N6Click(Sender: TObject); //меню сведения
 begin
  Form3.Visible:=True;  //делаем видимой элемент Form3
  Form1.Enabled:=False; // делаем недоступным элемент Form1
  Form3.edt1.Text:=way_city;  // Путь к файлу городов в edit1
  Form3.edt2.Text:=way_country;  // Путь к файлу стран в edit2
 end;

 procedure TForm1.N5Click(Sender: TObject); // Выход
 begin
   Application.Terminate; // Закрытие программы
 end;

 procedure TForm1.N3Click(Sender: TObject);  //меню переключиться на форму стран
 begin
  Form1.Visible:=False;   //делаем невидимым элемент Form1
  Form2.Left:=Form1.Left; //пододвигаем эл. Form2 до позиции Form1(по горизонтали)
  Form2.Top:=Form1.Top;   //пододвигаем эл. Form2 до позиции Form1(по вертикали)
  Form2.Visible:=True;    //делаем видимым элемент Form2
 end;

 procedure TForm1.edt1KeyPress(Sender: TObject; var Key: Char);  //Процедура нажатия на Enter
 begin
  if key=#13 then btn1.Click;
 end;

 procedure TForm1.edt2KeyPress(Sender: TObject; var Key: Char);  //Процедура нажатия на Enter

  begin
   if not (key in['0'..'9', #8 ,#13, #32]) then   // ограничение на ввод только цифр в поле жителей
    begin
     key:=#0;
    end;
    if key=#13 then btn1.Click;
  end;

 procedure TForm1.edt3KeyPress(Sender: TObject; var Key: Char);    //Процедура нажатия на Enter
  begin
   if key=#13 then btn1.Click;
  end;

 procedure TForm1.FormCreate(Sender: TObject);  // Процедура вывода сообщений при запуске программы
  begin
   if FileExists(way_city) then   // Проверка существования файла городов
    begin
     MessageBox(0,'Программа автоматически загрузила файлы открытые при прошлом запуске программы. '+#13#10+'Если вы не желаете продолжать работу с этими файлами, создайте новые или загрузите существующие.','Внимание',MB_OK);
    end
   else
    begin
     MessageBox(0,'Перед началом работы создайте или загрузите файлы стран и городов','Внимание',MB_OK);
    end;
  end;

begin  //считываем пути к файлам
 R := TRegistry.Create; //создаём объект TRegistry
 with R do
 begin
   RootKey := hkey_current_user; //устанавливаем корневой ключ; по умлочанию: hkey_current_user
   OpenKey('software\MyProg',True);  // открываем и создаём ключ,параметр true - если нет такого ключа, то создать его
   way_city := ReadString('way_city'); //путь к файлу городов
   way_country := ReadString('way_country'); //путь к файлу стран
   CloseKey; //закрываем ключ
   Free; //освобождаем ключ
 end;


end.




