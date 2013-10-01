object Form1: TForm1
  Left = 224
  Top = 205
  Width = 598
  Height = 405
  Caption = #1057#1090#1077#1082' '#1089' '#1084#1077#1090#1082#1086#1081' ('#1089#1086#1088#1090#1080#1088#1086#1074#1082#1072' '#1087#1091#1079#1099#1088#1100#1082#1086#1084')'
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
  object StringGrid1: TStringGrid
    Left = 8
    Top = 8
    Width = 161
    Height = 329
    ColCount = 2
    FixedCols = 0
    RowCount = 11
    Options = [goFixedVertLine, goFixedHorzLine, goVertLine, goHorzLine, goRangeSelect, goEditing]
    TabOrder = 0
  end
  object StringGrid2: TStringGrid
    Left = 384
    Top = 8
    Width = 161
    Height = 329
    ColCount = 2
    FixedCols = 0
    RowCount = 11
    Options = [goFixedVertLine, goFixedHorzLine, goVertLine, goHorzLine, goRangeSelect, goEditing]
    TabOrder = 1
  end
  object BitBtn1: TBitBtn
    Left = 224
    Top = 144
    Width = 105
    Height = 25
    Caption = #1057#1086#1088#1090#1080#1088#1086#1074#1072#1090#1100
    TabOrder = 2
    OnClick = BitBtn1Click
    Kind = bkRetry
  end
end
