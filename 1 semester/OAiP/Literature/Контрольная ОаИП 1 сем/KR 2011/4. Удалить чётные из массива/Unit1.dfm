object Form1: TForm1
  Left = 192
  Top = 124
  Width = 362
  Height = 232
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
    Width = 329
    Height = 49
    FixedCols = 0
    RowCount = 1
    FixedRows = 0
    Options = [goFixedVertLine, goFixedHorzLine, goVertLine, goHorzLine, goRangeSelect, goEditing]
    TabOrder = 0
  end
  object strngrd2: TStringGrid
    Left = 8
    Top = 136
    Width = 329
    Height = 49
    FixedCols = 0
    RowCount = 1
    FixedRows = 0
    Options = [goFixedVertLine, goFixedHorzLine, goVertLine, goHorzLine, goRangeSelect, goEditing]
    TabOrder = 1
  end
  object btn1: TButton
    Left = 104
    Top = 96
    Width = 121
    Height = 25
    Caption = #1059#1076#1072#1083#1080#1090#1100' '#1095#1105#1090#1085#1099#1077
    TabOrder = 2
    OnClick = btn1Click
  end
  object edt1: TEdit
    Left = 8
    Top = 64
    Width = 121
    Height = 21
    TabOrder = 3
    Text = 'edt1'
  end
  object btn2: TButton
    Left = 144
    Top = 64
    Width = 129
    Height = 25
    Caption = #1048#1079#1084#1077#1085#1080#1090#1100' '#1088#1072#1079#1084#1077#1088#1085#1086#1089#1090#1100
    TabOrder = 4
    OnClick = btn2Click
  end
end
