object Form1: TForm1
  Left = 192
  Top = 124
  Width = 200
  Height = 255
  Caption = #1048#1075#1085#1072#1090#1077#1085#1082#1086
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
    Width = 31
    Height = 19
    Caption = 'n = '
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
  end
  object edt1: TEdit
    Left = 8
    Top = 184
    Width = 169
    Height = 27
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    TabOrder = 0
    Text = 'edt1'
  end
  object edt2: TEdit
    Left = 40
    Top = 8
    Width = 137
    Height = 27
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    TabOrder = 1
    Text = 'edt2'
  end
  object rg1: TRadioGroup
    Left = 8
    Top = 40
    Width = 169
    Height = 105
    Caption = #1057#1087#1086#1089#1086#1073' '#1074#1099#1095#1080#1089#1083#1077#1085#1080#1103
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Tahoma'
    Font.Style = []
    Items.Strings = (
      #1056#1077#1082#1091#1088#1088#1077#1085#1090#1085#1086
      #1056#1077#1082#1091#1088#1089#1080#1074#1085#1086)
    ParentFont = False
    TabOrder = 2
  end
  object btn1: TButton
    Left = 40
    Top = 152
    Width = 97
    Height = 25
    Caption = #1042#1099#1095#1080#1089#1083#1080#1090#1100
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    TabOrder = 3
    OnClick = btn1Click
  end
end
