object Form1: TForm1
  Left = 210
  Top = 171
  Width = 154
  Height = 207
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
  object edt1: TEdit
    Left = 8
    Top = 8
    Width = 121
    Height = 24
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    TabOrder = 0
    Text = 'edt1'
  end
  object btn1: TButton
    Left = 32
    Top = 104
    Width = 75
    Height = 25
    Caption = #1055#1086#1076#1089#1095#1080#1090#1072#1090#1100
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    TabOrder = 1
    OnClick = btn1Click
  end
  object edt2: TEdit
    Left = 8
    Top = 136
    Width = 121
    Height = 24
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    TabOrder = 2
    Text = 'edt2'
  end
  object rg1: TRadioGroup
    Left = 16
    Top = 40
    Width = 105
    Height = 57
    HelpType = htKeyword
    Caption = #1042#1099#1095#1080#1089#1083#1080#1090#1100
    Items.Strings = (
      #1089#1091#1084#1084#1091
      #1087#1088#1086#1080#1079#1074#1077#1076#1077#1085#1080#1077)
    TabOrder = 3
  end
end
