object Form1: TForm1
  Left = 219
  Top = 187
  Width = 537
  Height = 507
  Caption = #1044#1074#1086#1080#1095#1085#1099#1081' '#1087#1086#1080#1089#1082' '#1087#1086' '#1082#1083#1102#1095#1091
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
    Left = 320
    Top = 104
    Width = 26
    Height = 13
    Caption = #1050#1083#1102#1095
  end
  object Label2: TLabel
    Left = 320
    Top = 224
    Width = 52
    Height = 13
    Caption = #1056#1077#1079#1091#1083#1100#1090#1072#1090
  end
  object StringGrid1: TStringGrid
    Left = 16
    Top = 16
    Width = 249
    Height = 409
    ColCount = 2
    FixedCols = 0
    RowCount = 10
    Options = [goFixedVertLine, goFixedHorzLine, goVertLine, goHorzLine, goRangeSelect, goEditing]
    TabOrder = 0
    ColWidths = (
      147
      64)
  end
  object Edit1: TEdit
    Left = 320
    Top = 128
    Width = 121
    Height = 21
    TabOrder = 1
    Text = 'Edit1'
  end
  object Edit2: TEdit
    Left = 320
    Top = 248
    Width = 121
    Height = 21
    TabOrder = 2
    Text = 'Edit2'
  end
  object BitBtn1: TBitBtn
    Left = 344
    Top = 176
    Width = 75
    Height = 25
    Caption = #1053#1072#1081#1090#1080
    TabOrder = 3
    OnClick = BitBtn1Click
    Kind = bkOK
  end
end
