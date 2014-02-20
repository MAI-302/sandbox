unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Unit2, Unit3, Menus,Registry;

type
    Tcity = record //������ "�����"
      name: string[50]; //���� �������� �����
   citizens: string[50]; //���� ������
       country: string[50]; //���� ������
            end;

  TForm1 = class(TForm)
    lbl1: TLabel;   //���������� Label
    lbl2: TLabel;
    lbl3: TLabel;
    edt1: TEdit;  //���������� Edit
    edt2: TEdit;
    edt3: TEdit;
    btn1: TButton;  // ������ '�������'
    mm1: TMainMenu;  // ��������� MainMenu
    df1: TMenuItem;  // ��������� �������� ���� '����'
    N1: TMenuItem;   // ����->�����
    N2: TMenuItem;   // ����->�������
    N4: TMenuItem;   // ����->��������� ���
    N6: TMenuItem;   // ��������
    dlgOpen1: TOpenDialog;   //������ �������� �����
    dlgSave1: TSaveDialog;   // ������ ���������� �����
    N3: TMenuItem;   // ������������� �� ���� �����
    N5: TMenuItem;   // �����
    procedure btn1Click(Sender: TObject);  //��� ������� �� ������ '�������'
    procedure N1Click(Sender: TObject);    // �������� ������ ����� �������
    procedure N6Click(Sender: TObject);    // ��������� ��������
    procedure N2Click(Sender: TObject);    // ������� ���� �������
    procedure N4Click(Sender: TObject);    // ��������� ���� �������
    procedure N3Click(Sender: TObject);    // ����������� �� ���� �����
    procedure N5Click(Sender: TObject);    // ��������� ���������
    procedure edt1KeyPress(Sender: TObject; var Key: Char); // ��������� ��� ������� ������� Enter
    procedure edt2KeyPress(Sender: TObject; var Key: Char);
    procedure edt3KeyPress(Sender: TObject; var Key: Char);
    procedure FormCreate(Sender: TObject);  //���������� � ������������� ������ ����� �������� ���������

  private
    { Private declarations }
  public
    { Public declarations }
  end;


  var
               R: TRegistry; //���������� ��� ������ � ��������
           Form1: TForm1;  //����� ����� �������
               i: Integer;   //�������� ����������
        way_city: ShortString; //���� � ����� �������
        way_country: ShortString; //���� � ���� �����
             buf: Tcity; //��������� ���������� ���� Tcity
              FP: file of Tcity;  //�������� ���������� ���� Tcity
  buttonSelected: Integer; //���������� ������ �������������

implementation

{$R *.dfm}

function nalcif(s:string): Boolean; //������� �������� �� �����, ���� ����, �� ���������� true
begin
  Result:= false;
  for i:=1 to length(s) do
  if (s[i] in ['0'..'9'])
  then begin Result:= True; Break; end; //��������� ��� ������ �� ������� ����, ���� �������, �� ��������� true. break - ����� �� �����
end;

procedure TForm1.btn1Click(Sender: TObject); //������ "�������"
begin
if way_city <> '' then
begin
  if (edt1.Text<>'') and (edt3.Text<>'') then //�������� ���������� ���� �����
    begin
      if not nalcif(edt1.Text) and not nalcif(edt3.Text) then  //�������� �� ����������  ����
       begin
        Assignfile(FP,way_city); //��������� �����-� FP � ������ �������
        Reset(FP); //�������� ����� �������
        i:=FileSize(FP); //����������� ���������� i �������� ���������� ��-�� FP
        buf.name:=edt1.Text;      //��������� ���� "�����" \
        buf.citizens:=edt2.Text; //��������� ���� "������"  |--> � buf(�����)
        buf.country:=edt3.Text;       //��������� ���� "������" /
        Seek(FP,i); //���������� ����-�� � ������� i (� ����� ����-�� � �������� �����-�� FP)
        write(FP,buf); //�����-�� �����-� buf � ���� (����-� � �������� �����-� FP)
        CloseFile(FP); //��������� ���� FP

        //������� ����
	    	edt1.Text:='';
        edt2.Text:='';
        edt3.Text:='';
        edt1.SetFocus; //���������� ����� �� ������ Edit
       end
      else ShowMessage('���� ''�������� ������'' � ''�������� ������'' �� ������ ��������� ����');
    end
  else ShowMessage('��������� ���� "�������� ������" � "�������� ������"'); //��������� ���������, � ������ �� ���������� ���� �����
end else ShowMessage('�� ������ ���� � ����� �������.'+#13+'�������� �����, ��� �������� ���� �������');
end;

 procedure TForm1.N1Click(Sender: TObject); //���� ����-->�����
begin 
  dlgSave1:= TSaveDialog.Create(self); //�������� �������
  dlgSave1.Title:='������� ����� ���� �������'; // ��������� ������ �������
  dlgSave1.Filter:='*.cit|*.cit';  // ��������� ������� ���� ���� *.cit
  dlgSave1.DefaultExt:='cit'; // ������ ����������, ������������� ������������ � ����� �����, ���� ������������ �� ������ ����������
  dlgsave1.Execute; // ����� ������� �������� �����  
  if FileExists(dlgSave1.FileName) then  //���� ������ ���� ����������  (FileExists ���������� �������� true ���� ���� ���������� )
     begin
      buttonSelected:= MessageDlg('�� ������������� ������ ������������ ���� '+dlgSave1.FileName, mtWarning, mbOKCancel, 0);
      if buttonSelected = mrYes then begin AssignFile(FP,dlgSave1.FileName); Rewrite(FP); end; //�������������� ����, ���� ������ ������ ��
      if buttonSelected = mrCancel then dlgSave1.FileName:=''; // ����� �� cancel ���������� ���������� dlgSave1.FileName
     end
  else begin  AssignFile(FP,dlgSave1.FileName); Rewrite(FP); end; //������� ����, ���� ���� �����������
  
  //���� ���� ����� ���� � ����� �������, �� ������� ��� � ��������� ����
  if (dlgSave1.FileName<>'') then
   begin // ���������� � ������ ����� ���� � ����� �������
    way_city := dlgSave1.FileName;
    R := TRegistry.Create;  // ������� ������ TRegistry
    R.OpenKey('software\MyProg',True); // ��������� � ������� ����, True - ���� ��� ������ ����� �� ������� ���
    R.WriteString('way_city',way_city); // ���������� ���� � ����� �������
    R.CloseKey; // ��������� ����
    R.Free;  // ����������� ����
   end;

  dlgSave1.Free;  //������������ �������
end;

 procedure TForm1.N2Click(Sender: TObject); //���� ����-->�������
begin
  dlgOpen1:=TOpenDialog.Create(Self);  //�������� �������
  dlgOpen1.Title:='������� ���� �������'; // ��������� ������ �������
  dlgOpen1.Filter:='*.cit|*.cit';  // ��������� ������� ���� ���� *.cit
  dlgOpen1.DefaultExt:='cit'; // ������ ����������, ������������� ������������ � ����� �����, ���� ������������ �� ������ ����������
  dlgOpen1.Execute; // ����� ������� �������� �����
  if FileExists(dlgOpen1.FileName) then  //���� ������ ���� ����������  (FileExists ���������� �������� true ���� ���� ���������� )
   begin
    way_city := dlgOpen1.FileName;
    R := TRegistry.Create;   // ������� ������ TRegistry
    R.OpenKey('software\MyProg',True); // ��������� � ������� ����, True - ���� ��� ������ ����� �� ������� ���
    R.WriteString('way_city',way_city);  // ���������� ���� � ����� �������
    R.CloseKey;  // ��������� ����
    R.Free;   // ����������� ����
   end;
  dlgOpen1.Free;  //������������ �������
end;

 procedure TForm1.N4Click(Sender: TObject); //���� ����-->��������� ���...
 begin
  dlgSave1:= TSaveDialog.Create(self); //�������� �������
  dlgSave1.Title:='��������� ���...'; // ��������� ������ �������
  dlgSave1.Filter:='*.cit|*.cit';  // ��������� ������� ���� ���� *.cit
  dlgSave1.DefaultExt:='cit'; // ������ ����������, ������������� ������������ � ����� �����, ���� ������������ �� ������ ����������
  dlgsave1.Execute;  // ����� ������� �������� �����
  if FileExists(dlgSave1.FileName) then  //���� ������ ���� ����������  (FileExists ���������� �������� ture ���� ���� ���������� )
     begin
      buttonSelected:= MessageDlg('�� ������������� ������ ������������ ���� '+dlgSave1.FileName, mtWarning, mbOKCancel, 0);
      if buttonSelected = mrYes then //�������������� ����, ���� ������ ������ ��
         CopyFile(Pchar(way_city + #0), Pchar(dlgSave1.FileName + #0), false); //�������� ���� � ����� �����(false �������� ��� ���������� ��� ���������� �����)
      if buttonSelected = mrCancel then dlgSave1.FileName:=''; // ����� �� cancel ���������� ���������� dlgSave1.FileName
     end
  else CopyFile(Pchar(way_city + #0), Pchar(dlgSave1.FileName + #0), false); //������� ����, ���� ���� �����������
  //���� ���� ����� ���� � ����� �������, �� ������� ��� � ������
  if (dlgSave1.FileName<>'') then
   begin
    way_city := dlgSave1.FileName;
    R := TRegistry.Create;  // ������� ������ TRegistry
    R.OpenKey('software\MyProg',True);  // ��������� � ������� ����, True - ���� ��� ������ ����� �� ������� ���
    R.WriteString('way_city',way_city); // ���������� ���� � ����� �������
    R.CloseKey;  // ��������� ����
    R.Free;   // ����������� ����
   end;

  dlgSave1.Free;  //������������ �������
 end;

 procedure TForm1.N6Click(Sender: TObject); //���� ��������
 begin
  Form3.Visible:=True;  //������ ������� ������� Form3
  Form1.Enabled:=False; // ������ ����������� ������� Form1
  Form3.edt1.Text:=way_city;  // ���� � ����� ������� � edit1
  Form3.edt2.Text:=way_country;  // ���� � ����� ����� � edit2
 end;

 procedure TForm1.N5Click(Sender: TObject); // �����
 begin
   Application.Terminate; // �������� ���������
 end;

 procedure TForm1.N3Click(Sender: TObject);  //���� ������������� �� ����� �����
 begin
  Form1.Visible:=False;   //������ ��������� ������� Form1
  Form2.Left:=Form1.Left; //����������� ��. Form2 �� ������� Form1(�� �����������)
  Form2.Top:=Form1.Top;   //����������� ��. Form2 �� ������� Form1(�� ���������)
  Form2.Visible:=True;    //������ ������� ������� Form2
 end;

 procedure TForm1.edt1KeyPress(Sender: TObject; var Key: Char);  //��������� ������� �� Enter
 begin
  if key=#13 then btn1.Click;
 end;

 procedure TForm1.edt2KeyPress(Sender: TObject; var Key: Char);  //��������� ������� �� Enter

  begin
   if not (key in['0'..'9', #8 ,#13, #32]) then   // ����������� �� ���� ������ ���� � ���� �������
    begin
     key:=#0;
    end;
    if key=#13 then btn1.Click;
  end;

 procedure TForm1.edt3KeyPress(Sender: TObject; var Key: Char);    //��������� ������� �� Enter
  begin
   if key=#13 then btn1.Click;
  end;

 procedure TForm1.FormCreate(Sender: TObject);  // ��������� ������ ��������� ��� ������� ���������
  begin
   if FileExists(way_city) then   // �������� ������������� ����� �������
    begin
     MessageBox(0,'��������� ������������� ��������� ����� �������� ��� ������� ������� ���������. '+#13#10+'���� �� �� ������� ���������� ������ � ����� �������, �������� ����� ��� ��������� ������������.','��������',MB_OK);
    end
   else
    begin
     MessageBox(0,'����� ������� ������ �������� ��� ��������� ����� ����� � �������','��������',MB_OK);
    end;
  end;

begin  //��������� ���� � ������
 R := TRegistry.Create; //������ ������ TRegistry
 with R do
 begin
   RootKey := hkey_current_user; //������������� �������� ����; �� ���������: hkey_current_user
   OpenKey('software\MyProg',True);  // ��������� � ������ ����,�������� true - ���� ��� ������ �����, �� ������� ���
   way_city := ReadString('way_city'); //���� � ����� �������
   way_country := ReadString('way_country'); //���� � ����� �����
   CloseKey; //��������� ����
   Free; //����������� ����
 end;


end.




