object Form1: TForm1
  Left = 127
  Top = 135
  Width = 497
  Height = 615
  Caption = #1051#1072#1073'. '#1088#1072#1073'. '#8470'9 '#1089#1090'. '#1075#1088'. 152003 '#1048#1075#1085#1072#1090#1077#1085#1082#1086' '#1040'.'#1040'.'
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
  object lbl9: TLabel
    Left = 184
    Top = 536
    Width = 7
    Height = 25
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -21
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
  end
  object btn2: TBitBtn
    Left = 384
    Top = 536
    Width = 89
    Height = 33
    Caption = #1042#1099#1093#1086#1076
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    TabOrder = 0
    Kind = bkClose
  end
  object pgc1: TPageControl
    Left = 8
    Top = 8
    Width = 465
    Height = 521
    ActivePage = ts1
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    TabOrder = 1
    object ts1: TTabSheet
      Caption = #1048#1089#1093#1086#1076#1085#1099#1077' '#1076#1072#1085#1085#1099#1077
      object lbl1: TLabel
        Left = 8
        Top = 56
        Width = 18
        Height = 19
        Caption = 'X1'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -16
        Font.Name = 'Tahoma'
        Font.Style = []
        ParentFont = False
      end
      object lbl2: TLabel
        Left = 8
        Top = 88
        Width = 18
        Height = 19
        Caption = 'X2'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -16
        Font.Name = 'Tahoma'
        Font.Style = []
        ParentFont = False
      end
      object lbl3: TLabel
        Left = 8
        Top = 120
        Width = 18
        Height = 19
        Caption = 'X3'
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -16
        Font.Name = 'Tahoma'
        Font.Style = []
        ParentFont = False
      end
      object lbl4: TLabel
        Left = 8
        Top = 152
        Width = 18
        Height = 19
        Caption = 'X4'
      end
      object lbl5: TLabel
        Left = 200
        Top = 56
        Width = 19
        Height = 19
        Caption = 'Y1'
      end
      object lbl6: TLabel
        Left = 200
        Top = 88
        Width = 19
        Height = 19
        Caption = 'Y2'
      end
      object lbl7: TLabel
        Left = 200
        Top = 120
        Width = 19
        Height = 19
        Caption = 'Y3'
      end
      object lbl8: TLabel
        Left = 200
        Top = 152
        Width = 19
        Height = 19
        Caption = 'Y4'
      end
      object edt1: TEdit
        Left = 40
        Top = 56
        Width = 121
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
        Top = 88
        Width = 121
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
      object edt3: TEdit
        Left = 40
        Top = 120
        Width = 121
        Height = 27
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -16
        Font.Name = 'Tahoma'
        Font.Style = []
        ParentFont = False
        TabOrder = 2
        Text = 'edt3'
      end
      object edt4: TEdit
        Left = 40
        Top = 152
        Width = 121
        Height = 27
        TabOrder = 3
        Text = 'edt4'
      end
      object edt5: TEdit
        Left = 232
        Top = 56
        Width = 121
        Height = 27
        TabOrder = 4
        Text = 'edt5'
      end
      object edt6: TEdit
        Left = 232
        Top = 88
        Width = 121
        Height = 27
        TabOrder = 5
        Text = 'edt6'
      end
      object edt7: TEdit
        Left = 232
        Top = 120
        Width = 121
        Height = 27
        TabOrder = 6
        Text = 'edt7'
      end
      object edt8: TEdit
        Left = 232
        Top = 152
        Width = 121
        Height = 27
        TabOrder = 7
        Text = 'edt8'
      end
    end
    object ts2: TTabSheet
      Caption = #1060#1080#1075#1091#1088#1072' [Image]'
      ImageIndex = 1
      object img1: TImage
        Left = 8
        Top = 8
        Width = 441
        Height = 441
      end
      object btn1: TButton
        Left = 144
        Top = 456
        Width = 153
        Height = 25
        Caption = #1055#1086#1089#1090#1088#1086#1080#1090#1100' '#1092#1080#1075#1091#1088#1091
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -16
        Font.Name = 'Tahoma'
        Font.Style = []
        ParentFont = False
        TabOrder = 0
        OnClick = btn1Click
      end
    end
  end
end
