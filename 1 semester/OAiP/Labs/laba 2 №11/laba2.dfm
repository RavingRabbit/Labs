object Form1: TForm1
  Left = 921
  Top = 63
  Width = 388
  Height = 359
  Caption = #1051#1072#1073'. '#1088#1072#1073'. '#8470'2 '#1057#1090'. '#1075#1088'. 152003 '#1048#1075#1085#1072#1090#1077#1085#1082#1086' '#1040'.'#1040'.'
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
  object lbl1: TLabel
    Left = 8
    Top = 8
    Width = 25
    Height = 23
    Caption = 'X='
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clDefault
    Font.Height = -19
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
  end
  object lbl2: TLabel
    Left = 8
    Top = 48
    Width = 25
    Height = 23
    Caption = 'Y='
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clDefault
    Font.Height = -19
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
  end
  object lbl3: TLabel
    Left = 8
    Top = 88
    Width = 25
    Height = 23
    Caption = 'Z='
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clDefault
    Font.Height = -19
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
  end
  object lbl4: TLabel
    Left = 64
    Top = 128
    Width = 269
    Height = 19
    Caption = #1056#1077#1079#1091#1083#1100#1090#1072#1090#1099' '#1074#1086#1087#1086#1083#1085#1077#1085#1080#1103' '#1087#1088#1086#1075#1088#1072#1084#1084#1099':'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
  end
  object edt1: TEdit
    Left = 40
    Top = 8
    Width = 121
    Height = 26
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -15
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    TabOrder = 0
    Text = 'edt1'
  end
  object edt2: TEdit
    Left = 40
    Top = 48
    Width = 121
    Height = 26
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -15
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    TabOrder = 1
    Text = 'edt2'
  end
  object edt3: TEdit
    Left = 40
    Top = 88
    Width = 121
    Height = 26
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -15
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    TabOrder = 2
    Text = 'edt3'
  end
  object mmo1: TMemo
    Left = 16
    Top = 160
    Width = 337
    Height = 153
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Tahoma'
    Font.Style = []
    Lines.Strings = (
      'mmo1')
    ParentFont = False
    TabOrder = 3
    OnClick = mmo1Click
  end
  object chk1: TCheckBox
    Left = 176
    Top = 8
    Width = 105
    Height = 17
    Caption = #1054#1082#1088#1091#1075#1083#1103#1090#1100
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    TabOrder = 4
  end
  object rg1: TRadioGroup
    Left = 176
    Top = 32
    Width = 145
    Height = 89
    Caption = 'u='
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Tahoma'
    Font.Style = []
    Items.Strings = (
      'sh(x)'
      'x^2'
      'e^x')
    ParentFont = False
    TabOrder = 5
  end
end
