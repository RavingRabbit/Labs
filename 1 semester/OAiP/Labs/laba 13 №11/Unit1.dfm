object Form1: TForm1
  Left = 191
  Top = 125
  BorderIcons = [biSystemMenu, biMinimize]
  BorderStyle = bsSingle
  Caption = #1051#1072#1073'. '#1088#1072#1073'. '#8470'13 '#1089#1090'. '#1075#1088'. 152003 '#1048#1075#1085#1072#1090#1077#1085#1082#1086' '#1040'.'#1040'.'
  ClientHeight = 386
  ClientWidth = 689
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -3
  Font.Name = 'Tahoma'
  Font.Style = []
  Menu = mm1
  OldCreateOrder = False
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 4
  object lbl1: TLabel
    Left = 8
    Top = 8
    Width = 60
    Height = 19
    Caption = #1060'. '#1048'. '#1054'.'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
  end
  object lbl2: TLabel
    Left = 8
    Top = 40
    Width = 44
    Height = 19
    Caption = #1040#1076#1088#1077#1089
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
  end
  object lbl3: TLabel
    Left = 8
    Top = 72
    Width = 103
    Height = 19
    Caption = #1057#1088#1077#1076#1085#1080#1081' '#1073#1072#1083#1083
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
  end
  object btn3: TButton
    Left = 176
    Top = 352
    Width = 105
    Height = 25
    Caption = #1057#1086#1088#1090#1080#1088#1086#1074#1072#1090#1100
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    TabOrder = 0
    OnClick = btn3Click
  end
  object btn5: TButton
    Left = 232
    Top = 72
    Width = 129
    Height = 25
    Caption = #1042#1074#1077#1089#1090#1080' '#1079#1072#1087#1080#1089#1100
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -17
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    TabOrder = 1
    OnClick = btn5Click
  end
  object btn6: TBitBtn
    Left = 600
    Top = 352
    Width = 81
    Height = 25
    Caption = #1042#1099#1093#1086#1076
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    TabOrder = 2
    Kind = bkClose
  end
  object edt1: TEdit
    Left = 128
    Top = 8
    Width = 369
    Height = 27
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    TabOrder = 3
    Text = 'edt1'
  end
  object edt2: TEdit
    Left = 128
    Top = 40
    Width = 369
    Height = 27
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    TabOrder = 4
    Text = 'edt2'
  end
  object edt3: TEdit
    Left = 128
    Top = 72
    Width = 97
    Height = 27
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    TabOrder = 5
    Text = 'edt3'
  end
  object mmo1: TMemo
    Left = 8
    Top = 104
    Width = 673
    Height = 241
    Font.Charset = RUSSIAN_CHARSET
    Font.Color = clWindowText
    Font.Height = -12
    Font.Name = 'Trebuchet MS'
    Font.Style = []
    Lines.Strings = (
      'mmo1')
    ParentFont = False
    ScrollBars = ssBoth
    TabOrder = 6
  end
  object btn8: TButton
    Left = 368
    Top = 72
    Width = 129
    Height = 25
    Hint = #1059#1076#1072#1083#1080#1090#1100' '#1079#1072#1087#1080#1089#1100' '#1087#1086' '#1079#1072#1076#1072#1085#1085#1086#1084#1091' '#1082#1083#1102#1095#1091
    Caption = #1059#1076#1072#1083#1080#1090#1100' '#1079#1072#1087#1080#1089#1100
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    ParentShowHint = False
    ShowHint = True
    TabOrder = 7
    OnClick = btn8Click
  end
  object cbb1: TComboBox
    Left = 8
    Top = 352
    Width = 161
    Height = 27
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Tahoma'
    Font.Style = []
    ItemHeight = 19
    ParentFont = False
    TabOrder = 8
    Text = #1052#1077#1090#1086#1076' '#1089#1086#1088#1090#1080#1088#1086#1074#1082#1080
    Items.Strings = (
      #1052#1077#1090#1086#1076' '#1089#1083#1080#1103#1085#1080#1103
      #1052#1077#1090#1086#1076' QuickSort')
  end
  object btn1: TButton
    Left = 504
    Top = 8
    Width = 145
    Height = 25
    Hint = #1083#1080#1085#1077#1081#1085#1099#1081' '#1087#1086#1080#1089#1082
    Caption = #1053#1072#1081#1090#1080' '#1074#1077#1076#1086#1084#1086#1089#1090#1100
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    ParentShowHint = False
    ShowHint = True
    TabOrder = 9
    OnClick = btn1Click
  end
  object btn2: TButton
    Left = 504
    Top = 72
    Width = 145
    Height = 25
    Hint = #1073#1080#1085#1072#1088#1085#1099#1081' '#1087#1086#1080#1089#1082
    Caption = #1053#1072#1081#1090#1080' ('#1073#1080#1085#1072#1088#1085#1086')'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    ParentShowHint = False
    ShowHint = True
    TabOrder = 10
    OnClick = btn2Click
  end
  object dlgOpen1: TOpenDialog
    DefaultExt = '.txt'
    FileName = 'Vedomosti.txt'
    Filter = #1058#1077#1082#1089#1090#1086#1074#1099#1081' '#1092#1072#1081#1083'|*.txt|'#1042#1089#1077' '#1092#1072#1081#1083#1099'|*.*'
    Left = 656
    Top = 8
  end
  object dlgSave1: TSaveDialog
    DefaultExt = '.txt'
    FileName = 'New Vedomosti.txt'
    Filter = #1058#1077#1082#1089#1090#1086#1074#1099#1081' '#1092#1072#1081#1083'|*.txt'
    Left = 640
    Top = 8
  end
  object mm1: TMainMenu
    Left = 624
    Top = 8
    object N1: TMenuItem
      Caption = #1057#1086#1079#1076#1072#1090#1100
      OnClick = N1Click
    end
    object N2: TMenuItem
      Caption = #1054#1090#1082#1088#1099#1090#1100
      OnClick = N2Click
    end
    object N3: TMenuItem
      Caption = #1057#1086#1093#1088#1072#1085#1080#1090#1100
      OnClick = N3Click
    end
  end
end
