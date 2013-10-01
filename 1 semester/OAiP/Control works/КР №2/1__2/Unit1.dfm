object Form1: TForm1
  Left = 191
  Top = 123
  Width = 312
  Height = 240
  Caption = 'Form1'
  Color = clBtnFace
  Font.Charset = RUSSIAN_CHARSET
  Font.Color = clWindowText
  Font.Height = -16
  Font.Name = 'Times New Roman'
  Font.Style = []
  OldCreateOrder = False
  OnClose = FormClose
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 19
  object Label1: TLabel
    Left = 168
    Top = 8
    Width = 38
    Height = 19
    Caption = #1050#1083#1102#1095
  end
  object Label2: TLabel
    Left = 168
    Top = 96
    Width = 63
    Height = 19
    Caption = #1056#1077#1079#1091#1083#1100#1090#1072#1090
  end
  object StringGrid1: TStringGrid
    Left = 8
    Top = 8
    Width = 153
    Height = 153
    ColCount = 2
    FixedCols = 0
    RowCount = 6
    Options = [goFixedVertLine, goFixedHorzLine, goVertLine, goHorzLine, goRangeSelect, goEditing, goTabs]
    ScrollBars = ssVertical
    TabOrder = 0
    ColWidths = (
      83
      64)
  end
  object Edit1: TEdit
    Left = 168
    Top = 32
    Width = 121
    Height = 27
    TabOrder = 1
    Text = 'Edit1'
  end
  object Button1: TButton
    Left = 8
    Top = 168
    Width = 153
    Height = 25
    Caption = #1042#1074#1077#1089#1090#1080' '#1076#1072#1085#1085#1099#1077
    TabOrder = 2
    OnClick = Button1Click
  end
  object Button2: TButton
    Left = 168
    Top = 64
    Width = 75
    Height = 25
    Caption = #1055#1086#1080#1089#1082
    TabOrder = 3
    OnClick = Button2Click
  end
  object Edit2: TEdit
    Left = 168
    Top = 120
    Width = 121
    Height = 27
    TabOrder = 4
    Text = 'Edit2'
  end
end
