object Form1: TForm1
  Left = 192
  Top = 124
  Width = 765
  Height = 557
  Caption = #1057#1086#1088#1090#1080#1088#1086#1074#1082#1072' '#1089#1083#1080#1103#1085#1080#1077#1084
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
    Left = 16
    Top = 16
    Width = 233
    Height = 449
    ColCount = 2
    FixedCols = 0
    RowCount = 11
    Options = [goFixedVertLine, goFixedHorzLine, goVertLine, goHorzLine, goRangeSelect, goEditing]
    TabOrder = 0
    ColWidths = (
      122
      64)
  end
  object StringGrid2: TStringGrid
    Left = 472
    Top = 16
    Width = 233
    Height = 449
    ColCount = 2
    FixedCols = 0
    RowCount = 11
    Options = [goFixedVertLine, goFixedHorzLine, goVertLine, goHorzLine, goRangeSelect, goEditing]
    TabOrder = 1
    ColWidths = (
      122
      64)
  end
  object BitBtn1: TBitBtn
    Left = 312
    Top = 200
    Width = 105
    Height = 25
    Caption = #1057#1086#1088#1090#1080#1088#1086#1074#1072#1090#1100
    TabOrder = 2
    OnClick = BitBtn1Click
    Kind = bkRetry
  end
end
