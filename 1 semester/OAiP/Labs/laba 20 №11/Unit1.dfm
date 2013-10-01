object Form1: TForm1
  Left = 192
  Top = 124
  Width = 409
  Height = 303
  Caption = #1051#1072#1073'. '#1088#1072#1073'. '#8470'20 '#1089#1090'.'#1075#1088'. 152003 '#1048#1075#1085#1072#1090#1077#1085#1082#1086' '#1040#1085#1076#1088#1077#1103' '#1040#1083#1077#1082#1089#1072#1085#1076#1088#1086#1074#1080#1095#1072
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -15
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 18
  object lbl1: TLabel
    Left = 8
    Top = 8
    Width = 157
    Height = 18
    Caption = #1056#1072#1079#1084#1077#1088#1085#1086#1089#1090#1100' '#1084#1072#1090#1088#1080#1094#1072':'
  end
  object lbl2: TLabel
    Left = 344
    Top = 224
    Width = 8
    Height = 33
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -27
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
  end
  object strngrd1: TStringGrid
    Left = 8
    Top = 64
    Width = 329
    Height = 129
    Options = [goFixedVertLine, goFixedHorzLine, goVertLine, goHorzLine, goRangeSelect, goEditing, goTabs]
    TabOrder = 0
  end
  object btn1: TButton
    Left = 200
    Top = 200
    Width = 137
    Height = 25
    Caption = #1057#1086#1079#1076#1072#1090#1100' '#1084#1072#1090#1088#1080#1094#1091
    TabOrder = 1
    OnClick = btn1Click
  end
  object edt1: TEdit
    Left = 8
    Top = 32
    Width = 65
    Height = 26
    TabOrder = 2
    Text = '4'
  end
  object btn2: TButton
    Left = 80
    Top = 32
    Width = 89
    Height = 25
    Caption = #1048#1079#1084#1077#1085#1080#1090#1100
    TabOrder = 3
    OnClick = btn2Click
  end
  object btn3: TButton
    Left = 8
    Top = 232
    Width = 329
    Height = 25
    Caption = #1055#1086#1076#1089#1095#1080#1090#1072#1090#1100' '#1089#1091#1084#1084#1091' '#1076#1080#1072#1075#1086#1085#1072#1083#1100#1085#1099#1093' '#1101#1083#1077#1084#1077#1085#1090#1086#1074' '
    TabOrder = 4
    OnClick = btn3Click
  end
end
