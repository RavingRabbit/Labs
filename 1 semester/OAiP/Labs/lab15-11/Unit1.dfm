object Form1: TForm1
  Left = 194
  Top = 123
  BiDiMode = bdLeftToRight
  BorderStyle = bsSingle
  Caption = #1051#1072#1073'. '#1088#1072#1073'. '#8470'15 '#1089#1090'.'#1075#1088'. 152003 '#1048#1075#1085#1072#1090#1077#1085#1082#1086' '#1040#1085#1076#1088#1077#1103' '#1040#1083#1077#1082#1089#1072#1085#1076#1088#1086#1074#1080#1095#1072
  ClientHeight = 338
  ClientWidth = 553
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -16
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  ParentBiDiMode = False
  OnCreate = FormCreate
  OnDblClick = FormDblClick
  PixelsPerInch = 96
  TextHeight = 19
  object lbl2: TLabel
    Left = 160
    Top = 8
    Width = 277
    Height = 19
    Caption = #1057#1086#1079#1076#1072#1090#1100' '#1089#1090#1077#1082' '#1080#1079'       '#1101#1083#1077#1084#1077#1085#1090#1086#1074'        '#1080
  end
  object shp1: TShape
    Left = 144
    Top = 5
    Width = 4
    Height = 328
  end
  object img1: TImage
    Left = 288
    Top = 40
    Width = 257
    Height = 257
    Visible = False
  end
  object lst1: TListBox
    Left = 8
    Top = 40
    Width = 121
    Height = 257
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Tahoma'
    Font.Style = []
    ItemHeight = 19
    ParentFont = False
    TabOrder = 0
  end
  object edt1: TEdit
    Left = 8
    Top = 8
    Width = 57
    Height = 27
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    TabOrder = 1
    Text = '15'
  end
  object btn3: TButton
    Left = 440
    Top = 8
    Width = 105
    Height = 25
    Hint = ' (print)'
    Caption = #1088#1072#1089#1087#1077#1095#1072#1090#1072#1090#1100
    Enabled = False
    ParentShowHint = False
    ShowHint = True
    TabOrder = 2
    OnClick = btn3Click
  end
  object Button1: TButton
    Left = 72
    Top = 304
    Width = 57
    Height = 25
    Caption = 'Read'
    Enabled = False
    TabOrder = 3
    OnClick = Button1Click
  end
  object edt3: TEdit
    Left = 8
    Top = 304
    Width = 57
    Height = 27
    Enabled = False
    TabOrder = 4
  end
  object btn1: TButton
    Left = 72
    Top = 8
    Width = 57
    Height = 25
    Caption = 'Add'
    TabOrder = 5
    OnClick = btn1Click
  end
  object edt4: TEdit
    Left = 280
    Top = 8
    Width = 25
    Height = 27
    TabOrder = 6
    Text = '10'
  end
  object btn4: TBitBtn
    Left = 392
    Top = 8
    Width = 33
    Height = 25
    Caption = ' '
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -1
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    TabOrder = 7
    OnClick = btn4Click
    Kind = bkAll
  end
  object btn5: TButton
    Left = 160
    Top = 304
    Width = 385
    Height = 25
    Caption = #1052#1080#1085#1080#1084#1072#1083#1100#1085#1099#1081' <> '#1084#1072#1082#1089#1080#1084#1072#1083#1100#1085#1099#1081' '#1101#1083#1077#1084#1077#1085#1090#1099
    Enabled = False
    Font.Charset = ANSI_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    TabOrder = 8
    OnClick = btn5Click
  end
  object lst2: TListBox
    Left = 160
    Top = 40
    Width = 121
    Height = 257
    ItemHeight = 19
    TabOrder = 9
  end
end
