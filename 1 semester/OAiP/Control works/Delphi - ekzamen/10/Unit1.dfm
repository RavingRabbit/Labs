object Form1: TForm1
  Left = 192
  Top = 124
  Width = 498
  Height = 381
  Caption = #1056#1072#1089#1089#1095#1077#1090' '#1074#1099#1088#1072#1078#1077#1085#1080#1103' '#1074' '#1087#1086#1089#1090#1092#1080#1082#1089#1085#1086#1081' '#1092#1086#1088#1084#1077
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
    Left = 232
    Top = 56
    Width = 178
    Height = 13
    Caption = #1042#1099#1088#1072#1078#1077#1085#1080#1077' '#1074' '#1087#1086#1089#1090#1092#1080#1082#1089#1085#1086#1081' '#1092#1086#1088#1084#1077':'
  end
  object Label2: TLabel
    Left = 232
    Top = 168
    Width = 52
    Height = 13
    Caption = #1056#1077#1079#1091#1083#1100#1090#1072#1090
  end
  object StringGrid1: TStringGrid
    Left = 8
    Top = 8
    Width = 169
    Height = 305
    ColCount = 2
    FixedCols = 0
    RowCount = 11
    Options = [goFixedVertLine, goFixedHorzLine, goVertLine, goHorzLine, goRangeSelect, goEditing]
    TabOrder = 0
    ColWidths = (
      80
      64)
  end
  object Edit1: TEdit
    Left = 232
    Top = 72
    Width = 177
    Height = 21
    TabOrder = 1
    Text = 'Edit1'
  end
  object Edit2: TEdit
    Left = 232
    Top = 184
    Width = 121
    Height = 21
    TabOrder = 2
    Text = 'Edit2'
  end
  object BitBtn1: TBitBtn
    Left = 248
    Top = 120
    Width = 97
    Height = 25
    Caption = #1055#1086#1089#1095#1080#1090#1072#1090#1100
    TabOrder = 3
    OnClick = BitBtn1Click
    Kind = bkOK
  end
end
