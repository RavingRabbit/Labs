object Form1: TForm1
  Left = 180
  Top = 125
  Width = 425
  Height = 230
  Caption = #1051#1072#1073'. '#1088#1072#1073'. '#8470'5 '#1089#1090'. '#1075#1088'. 152003 '#1048#1075#1085#1072#1090#1077#1085#1082#1086' '#1040'.'#1040'.'
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
  object Label1: TLabel
    Left = 8
    Top = 96
    Width = 154
    Height = 18
    Caption = #1056#1072#1079#1084#1077#1088#1085#1086#1089#1090#1100' '#1084#1072#1089#1089#1080#1074#1072':'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -15
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
  end
  object btn1: TBitBtn
    Left = 328
    Top = 160
    Width = 75
    Height = 25
    Caption = #1042#1099#1093#1086#1076
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -12
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    TabOrder = 0
    Kind = bkClose
  end
  object strngrd1: TStringGrid
    Left = 8
    Top = 8
    Width = 393
    Height = 49
    ColCount = 6
    FixedCols = 0
    RowCount = 1
    FixedRows = 0
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Tahoma'
    Font.Style = []
    Options = [goFixedVertLine, goFixedHorzLine, goVertLine, goHorzLine, goRangeSelect, goEditing]
    ParentFont = False
    TabOrder = 1
  end
  object edt1: TEdit
    Left = 168
    Top = 96
    Width = 57
    Height = 26
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -15
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    TabOrder = 2
    Text = 'edt1'
  end
  object btn2: TButton
    Left = 232
    Top = 96
    Width = 169
    Height = 25
    Caption = #1080#1079#1084#1077#1085#1080#1090#1100' '#1088#1072#1079#1084#1077#1088#1085#1086#1089#1090#1100
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -15
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    TabOrder = 3
    OnClick = btn2Click
  end
  object btn3: TButton
    Left = 8
    Top = 128
    Width = 265
    Height = 25
    Caption = #1054#1087#1088#1077#1076#1077#1083#1080#1090#1100' '#1082#1086#1083#1080#1095#1077#1089#1090#1074#1086' '#1080#1085#1074#1077#1088#1089#1080#1081
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -15
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    TabOrder = 4
    OnClick = btn3Click
  end
  object edt2: TEdit
    Left = 280
    Top = 128
    Width = 121
    Height = 26
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -15
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    TabOrder = 5
    Text = 'edt2'
  end
  object btn4: TBitBtn
    Left = 40
    Top = 64
    Width = 329
    Height = 25
    Caption = #1047#1072#1087#1086#1083#1085#1080#1090#1100' '#1084#1072#1089#1089#1080#1074' '#1089#1083#1091#1095#1072#1081#1085#1099#1084#1080' '#1095#1080#1089#1083#1072#1084#1080
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -15
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    TabOrder = 6
    OnClick = btn4Click
    Kind = bkAll
  end
end
