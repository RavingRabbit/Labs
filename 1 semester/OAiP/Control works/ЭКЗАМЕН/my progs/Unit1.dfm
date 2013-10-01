object Form1: TForm1
  Left = 191
  Top = 99
  Width = 928
  Height = 479
  Caption = 'Form1'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 13
  object Image1: TImage
    Left = 8
    Top = 0
    Width = 889
    Height = 385
  end
  object Button1: TButton
    Left = 48
    Top = 400
    Width = 75
    Height = 25
    Caption = 'narosovat'#39
    TabOrder = 0
    OnClick = Button1Click
  end
  object Button2: TButton
    Left = 256
    Top = 400
    Width = 75
    Height = 25
    Caption = 'vlevo'
    TabOrder = 1
  end
  object Button3: TButton
    Left = 520
    Top = 400
    Width = 75
    Height = 25
    Caption = 'vpravo'
    TabOrder = 2
  end
  object Button4: TButton
    Left = 384
    Top = 384
    Width = 75
    Height = 25
    Caption = 'vverh '
    TabOrder = 3
  end
  object Button5: TButton
    Left = 384
    Top = 408
    Width = 75
    Height = 25
    Caption = 'vniz'
    TabOrder = 4
  end
  object Button6: TButton
    Left = 696
    Top = 400
    Width = 75
    Height = 25
    Caption = 'destroy'
    TabOrder = 5
    OnClick = Button6Click
  end
end
