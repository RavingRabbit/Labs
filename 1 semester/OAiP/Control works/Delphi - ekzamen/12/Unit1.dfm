object Form1: TForm1
  Left = 192
  Top = 124
  Width = 580
  Height = 375
  Caption = #1044#1074#1086#1080#1095#1085#1086#1077' '#1076#1077#1088#1077#1074#1086' ('#1074#1074#1077#1089#1090#1080' '#1080' '#1074#1099#1074#1077#1089#1090#1080')'
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
  object Label1: TLabel
    Left = 224
    Top = 40
    Width = 117
    Height = 13
    Caption = #1050#1086#1083#1080#1095#1077#1089#1090#1074#1086' '#1101#1083#1077#1084#1077#1085#1090#1086#1074
  end
  object StringGrid1: TStringGrid
    Left = 8
    Top = 8
    Width = 177
    Height = 321
    ColCount = 2
    FixedCols = 0
    RowCount = 11
    Options = [goFixedVertLine, goFixedHorzLine, goVertLine, goHorzLine, goRangeSelect, goEditing]
    TabOrder = 0
    ColWidths = (
      83
      64)
  end
  object StringGrid2: TStringGrid
    Left = 376
    Top = 8
    Width = 177
    Height = 321
    ColCount = 2
    FixedCols = 0
    RowCount = 11
    Options = [goFixedVertLine, goFixedHorzLine, goVertLine, goHorzLine, goRangeSelect, goEditing]
    TabOrder = 1
    ColWidths = (
      83
      64)
  end
  object Button1: TButton
    Left = 240
    Top = 120
    Width = 75
    Height = 25
    Caption = #1042#1074#1077#1089#1090#1080
    TabOrder = 2
    OnClick = Button1Click
  end
  object Button2: TButton
    Left = 240
    Top = 176
    Width = 75
    Height = 25
    Caption = #1042#1099#1074#1077#1089#1090#1080
    TabOrder = 3
    OnClick = Button2Click
  end
  object Edit1: TEdit
    Left = 224
    Top = 64
    Width = 121
    Height = 21
    TabOrder = 4
    Text = 'Edit1'
  end
end
