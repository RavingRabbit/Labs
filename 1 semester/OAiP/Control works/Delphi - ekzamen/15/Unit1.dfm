object Form1: TForm1
  Left = 192
  Top = 124
  Width = 420
  Height = 397
  Caption = #1041#1080#1085#1072#1088#1085#1086#1077' '#1076#1077#1088#1077#1074#1086'. '#1055#1086#1080#1089#1082' '#1087#1086' '#1082#1083#1102#1095#1091
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
    Left = 200
    Top = 112
    Width = 26
    Height = 13
    Caption = #1050#1083#1102#1095
  end
  object Label2: TLabel
    Left = 200
    Top = 200
    Width = 52
    Height = 13
    Caption = #1056#1077#1079#1091#1083#1100#1090#1072#1090
  end
  object StringGrid1: TStringGrid
    Left = 8
    Top = 8
    Width = 161
    Height = 313
    ColCount = 2
    FixedCols = 0
    RowCount = 11
    Options = [goFixedVertLine, goFixedHorzLine, goVertLine, goHorzLine, goRangeSelect, goEditing]
    TabOrder = 0
  end
  object Button1: TButton
    Left = 192
    Top = 40
    Width = 169
    Height = 25
    Caption = #1057#1086#1079#1076#1072#1090#1100' '#1076#1077#1088#1077#1074#1086
    TabOrder = 1
    OnClick = Button1Click
  end
  object Edit1: TEdit
    Left = 200
    Top = 128
    Width = 121
    Height = 21
    TabOrder = 2
    Text = 'Edit1'
  end
  object Button2: TButton
    Left = 200
    Top = 160
    Width = 121
    Height = 25
    Caption = #1055#1086#1080#1089#1082' '#1087#1086' '#1082#1083#1102#1095#1091
    TabOrder = 3
    OnClick = Button2Click
  end
  object Memo1: TMemo
    Left = 200
    Top = 216
    Width = 169
    Height = 121
    Lines.Strings = (
      'Memo1')
    TabOrder = 4
  end
  object Button3: TButton
    Left = 192
    Top = 72
    Width = 169
    Height = 25
    Caption = #1059#1076#1072#1083#1080#1090#1100' '#1076#1077#1088#1077#1074#1086
    TabOrder = 5
    OnClick = Button3Click
  end
end
