object Form1: TForm1
  Left = 192
  Top = 124
  Width = 682
  Height = 422
  Caption = #1051#1072#1073'.'#1088#1072#1073'. '#8470'19 '#1089#1090'.'#1075#1088'. 152003 '#1048#1075#1085#1072#1090#1077#1085#1082#1086' '#1040#1085#1076#1088#1077#1103' '#1040#1083#1077#1082#1089#1072#1085#1076#1088#1086#1074#1080#1095#1072
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
    Width = 124
    Height = 18
    Caption = #1063#1080#1089#1083#1086' '#1101#1083#1077#1084#1077#1085#1090#1086#1074':'
  end
  object lbl2: TLabel
    Left = 264
    Top = 8
    Width = 241
    Height = 18
    Caption = #1044#1086#1073#1072#1074#1080#1090#1100' '#1101#1083#1077#1084#1077#1085#1090' '#1074' '#1093#1077#1096'-'#1090#1072#1073#1083#1080#1094#1091':'
  end
  object lbl3: TLabel
    Left = 264
    Top = 120
    Width = 195
    Height = 18
    Caption = #1055#1088#1086#1095#1077#1089#1090#1100' '#1080' '#1091#1076#1072#1083#1080#1090#1100' '#1079#1072#1087#1080#1089#1100':'
  end
  object lbl4: TLabel
    Left = 520
    Top = 8
    Width = 119
    Height = 18
    Caption = #1042#1099#1076#1072#1090#1100' '#1076#1072#1085#1085#1099#1077' '#1080
  end
  object lbl5: TLabel
    Left = 520
    Top = 32
    Width = 139
    Height = 18
    Caption = #1086#1089#1074#1086#1073#1086#1076#1080#1090#1100' '#1087#1072#1084#1103#1090#1100':'
  end
  object shp1: TShape
    Left = 248
    Top = 8
    Width = 1
    Height = 285
  end
  object shp2: TShape
    Left = 512
    Top = 8
    Width = 1
    Height = 285
  end
  object lbl6: TLabel
    Left = 264
    Top = 232
    Width = 244
    Height = 18
    Caption = #1054#1087#1088#1077#1076#1077#1083#1080#1090#1100' '#1082#1086#1083#1080#1095#1077#1089#1090#1074#1086' '#1101#1083#1077#1084#1077#1085#1090#1086#1074
  end
  object lbl7: TLabel
    Left = 264
    Top = 256
    Width = 106
    Height = 18
    Caption = #1074' '#1082#1072#1078#1086#1084' '#1089#1090#1077#1082#1077':'
  end
  object edt1: TEdit
    Left = 8
    Top = 232
    Width = 65
    Height = 26
    TabOrder = 0
    Text = '60'
  end
  object btn1: TButton
    Left = 80
    Top = 232
    Width = 161
    Height = 25
    Caption = #1057#1086#1079#1076#1072#1090#1100' '#1093#1077#1096'-'#1090#1072#1073#1083#1080#1094#1091
    TabOrder = 1
    OnClick = btn1Click
  end
  object strngrd1: TStringGrid
    Left = 8
    Top = 64
    Width = 133
    Height = 153
    ColCount = 2
    FixedCols = 0
    RowCount = 6
    TabOrder = 2
  end
  object btn2: TButton
    Left = 8
    Top = 264
    Width = 233
    Height = 25
    Caption = #1047#1072#1085#1077#1089#1090#1080' '#1076#1072#1085#1085#1099#1077' '#1093#1077#1096'-'#1090#1072#1073#1083#1080#1094#1091
    Enabled = False
    TabOrder = 3
    OnClick = btn2Click
  end
  object edt2: TEdit
    Left = 8
    Top = 32
    Width = 81
    Height = 26
    TabOrder = 4
    Text = '5'
  end
  object btn3: TBitBtn
    Left = 96
    Top = 32
    Width = 57
    Height = 25
    Caption = ' '
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -1
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    TabOrder = 5
    OnClick = btn3Click
    Kind = bkOK
  end
  object lbledt1: TLabeledEdit
    Left = 264
    Top = 48
    Width = 65
    Height = 26
    EditLabel.Width = 31
    EditLabel.Height = 18
    EditLabel.Caption = #1060#1048#1054
    TabOrder = 6
  end
  object lbledt2: TLabeledEdit
    Left = 336
    Top = 48
    Width = 57
    Height = 26
    EditLabel.Width = 36
    EditLabel.Height = 18
    EditLabel.Caption = #1050#1083#1102#1095
    TabOrder = 7
  end
  object btn4: TButton
    Left = 264
    Top = 80
    Width = 75
    Height = 25
    Caption = #1044#1086#1073#1072#1074#1080#1090#1100
    Enabled = False
    TabOrder = 8
    OnClick = btn4Click
  end
  object lbledt3: TLabeledEdit
    Left = 264
    Top = 160
    Width = 65
    Height = 26
    EditLabel.Width = 36
    EditLabel.Height = 18
    EditLabel.Caption = #1050#1083#1102#1095
    TabOrder = 9
  end
  object btn5: TBitBtn
    Left = 336
    Top = 160
    Width = 57
    Height = 25
    Caption = ' '
    Enabled = False
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -1
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    TabOrder = 10
    OnClick = btn5Click
    Kind = bkOK
  end
  object edt3: TEdit
    Left = 264
    Top = 192
    Width = 129
    Height = 26
    TabOrder = 11
  end
  object btn6: TButton
    Left = 520
    Top = 56
    Width = 137
    Height = 25
    Caption = #1042#1099#1087#1086#1083#1085#1080#1090#1100
    TabOrder = 12
    OnClick = btn6Click
  end
  object strngrd2: TStringGrid
    Left = 520
    Top = 88
    Width = 133
    Height = 153
    ColCount = 2
    FixedCols = 0
    RowCount = 6
    TabOrder = 13
  end
  object btn7: TButton
    Left = 376
    Top = 254
    Width = 89
    Height = 25
    Caption = #1042#1099#1087#1086#1083#1085#1080#1090#1100
    Enabled = False
    TabOrder = 14
    OnClick = btn7Click
  end
  object mmo1: TMemo
    Left = 264
    Top = 288
    Width = 241
    Height = 89
    TabOrder = 15
  end
end
