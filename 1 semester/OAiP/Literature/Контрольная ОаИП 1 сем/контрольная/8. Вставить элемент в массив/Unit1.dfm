object Form1: TForm1
  Left = 192
  Top = 124
  Width = 362
  Height = 247
  Caption = 'Form1'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 13
  object strngrd1: TStringGrid
    Left = 8
    Top = 8
    Width = 330
    Height = 49
    FixedCols = 0
    RowCount = 1
    FixedRows = 0
    Options = [goFixedVertLine, goFixedHorzLine, goVertLine, goHorzLine, goRangeSelect, goEditing]
    ScrollBars = ssHorizontal
    TabOrder = 0
  end
  object strngrd2: TStringGrid
    Left = 8
    Top = 152
    Width = 330
    Height = 49
    FixedCols = 0
    RowCount = 1
    FixedRows = 0
    ScrollBars = ssHorizontal
    TabOrder = 1
  end
  object edt1: TEdit
    Left = 24
    Top = 72
    Width = 121
    Height = 21
    TabOrder = 2
    Text = 'edt1'
  end
  object btn1: TButton
    Left = 168
    Top = 64
    Width = 145
    Height = 25
    Caption = #1048#1079#1084#1077#1085#1080#1090#1100' '#1088#1072#1079#1084#1077#1088#1085#1086#1089#1090#1100
    TabOrder = 3
    OnClick = btn1Click
  end
  object edt2: TEdit
    Left = 24
    Top = 104
    Width = 121
    Height = 21
    TabOrder = 4
    Text = 'edt2'
  end
  object btn2: TButton
    Left = 192
    Top = 104
    Width = 75
    Height = 25
    Caption = #1042#1089#1090#1072#1074#1080#1090#1100
    TabOrder = 5
    OnClick = btn2Click
  end
end
