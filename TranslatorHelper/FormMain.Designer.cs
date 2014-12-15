namespace TranslatorHelper
{
  partial class FormMain
  {
    /// <summary>
    /// Variable nécessaire au concepteur.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Nettoyage des ressources utilisées.
    /// </summary>
    /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Code généré par le Concepteur Windows Form

    /// <summary>
    /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
    /// le contenu de cette méthode avec l'éditeur de code.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.nouveauToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.ouvrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
      this.enregistrerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.enregistrersousToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.imprimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.aperçuavantimpressionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.editionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.annulerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.rétablirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
      this.couperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.copierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.collerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
      this.sélectionnertoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.outilsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.frenchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tabPageTranslation = new System.Windows.Forms.TabPage();
      this.buttonConvert = new System.Windows.Forms.Button();
      this.labelTranslatedFileName = new System.Windows.Forms.Label();
      this.textBoxTranslatedFileName = new System.Windows.Forms.TextBox();
      this.textBoxSuffixeFileName = new System.Windows.Forms.TextBox();
      this.labelSuffixeFileName = new System.Windows.Forms.Label();
      this.buttonChooseFile = new System.Windows.Forms.Button();
      this.labelFilePath = new System.Windows.Forms.Label();
      this.textBoxfilePath = new System.Windows.Forms.TextBox();
      this.tabPageInput = new System.Windows.Forms.TabPage();
      this.buttonAddToDictionary = new System.Windows.Forms.Button();
      this.textBoxInputEnglish = new System.Windows.Forms.TextBox();
      this.labelInputEnglish = new System.Windows.Forms.Label();
      this.textBoxInputFrench = new System.Windows.Forms.TextBox();
      this.labelInputFrench = new System.Windows.Forms.Label();
      this.tabPageEditDictionary = new System.Windows.Forms.TabPage();
      this.tabPageAutoLearning = new System.Windows.Forms.TabPage();
      this.buttonPickEnglishDocument = new System.Windows.Forms.Button();
      this.buttonPickFrenchDocument = new System.Windows.Forms.Button();
      this.textBoxEnglishDocument = new System.Windows.Forms.TextBox();
      this.labelEnglishDocument = new System.Windows.Forms.Label();
      this.textBoxFrenchDocument = new System.Windows.Forms.TextBox();
      this.labelFrenchDocument = new System.Windows.Forms.Label();
      this.buttonAutoLearning = new System.Windows.Forms.Button();
      this.tabPageTool = new System.Windows.Forms.TabPage();
      this.buttonWords = new System.Windows.Forms.Button();
      this.buttonCountParagraph = new System.Windows.Forms.Button();
      this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
      this.menuStrip1.SuspendLayout();
      this.tabControl1.SuspendLayout();
      this.tabPageTranslation.SuspendLayout();
      this.tabPageInput.SuspendLayout();
      this.tabPageAutoLearning.SuspendLayout();
      this.tabPageTool.SuspendLayout();
      this.SuspendLayout();
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editionToolStripMenuItem,
            this.outilsToolStripMenuItem,
            this.languageToolStripMenuItem,
            this.helpToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(1449, 28);
      this.menuStrip1.TabIndex = 0;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nouveauToolStripMenuItem,
            this.ouvrirToolStripMenuItem,
            this.toolStripSeparator,
            this.enregistrerToolStripMenuItem,
            this.enregistrersousToolStripMenuItem,
            this.toolStripSeparator1,
            this.imprimerToolStripMenuItem,
            this.aperçuavantimpressionToolStripMenuItem,
            this.toolStripSeparator2,
            this.quitToolStripMenuItem});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
      this.fileToolStripMenuItem.Text = "&Fichier";
      // 
      // nouveauToolStripMenuItem
      // 
      this.nouveauToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("nouveauToolStripMenuItem.Image")));
      this.nouveauToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.nouveauToolStripMenuItem.Name = "nouveauToolStripMenuItem";
      this.nouveauToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
      this.nouveauToolStripMenuItem.Size = new System.Drawing.Size(241, 24);
      this.nouveauToolStripMenuItem.Text = "&Nouveau";
      // 
      // ouvrirToolStripMenuItem
      // 
      this.ouvrirToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ouvrirToolStripMenuItem.Image")));
      this.ouvrirToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.ouvrirToolStripMenuItem.Name = "ouvrirToolStripMenuItem";
      this.ouvrirToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
      this.ouvrirToolStripMenuItem.Size = new System.Drawing.Size(241, 24);
      this.ouvrirToolStripMenuItem.Text = "&Ouvrir";
      // 
      // toolStripSeparator
      // 
      this.toolStripSeparator.Name = "toolStripSeparator";
      this.toolStripSeparator.Size = new System.Drawing.Size(238, 6);
      // 
      // enregistrerToolStripMenuItem
      // 
      this.enregistrerToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("enregistrerToolStripMenuItem.Image")));
      this.enregistrerToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.enregistrerToolStripMenuItem.Name = "enregistrerToolStripMenuItem";
      this.enregistrerToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
      this.enregistrerToolStripMenuItem.Size = new System.Drawing.Size(241, 24);
      this.enregistrerToolStripMenuItem.Text = "&Enregistrer";
      // 
      // enregistrersousToolStripMenuItem
      // 
      this.enregistrersousToolStripMenuItem.Name = "enregistrersousToolStripMenuItem";
      this.enregistrersousToolStripMenuItem.Size = new System.Drawing.Size(241, 24);
      this.enregistrersousToolStripMenuItem.Text = "Enregistrer &sous";
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(238, 6);
      // 
      // imprimerToolStripMenuItem
      // 
      this.imprimerToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("imprimerToolStripMenuItem.Image")));
      this.imprimerToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.imprimerToolStripMenuItem.Name = "imprimerToolStripMenuItem";
      this.imprimerToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
      this.imprimerToolStripMenuItem.Size = new System.Drawing.Size(241, 24);
      this.imprimerToolStripMenuItem.Text = "&Imprimer";
      // 
      // aperçuavantimpressionToolStripMenuItem
      // 
      this.aperçuavantimpressionToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("aperçuavantimpressionToolStripMenuItem.Image")));
      this.aperçuavantimpressionToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.aperçuavantimpressionToolStripMenuItem.Name = "aperçuavantimpressionToolStripMenuItem";
      this.aperçuavantimpressionToolStripMenuItem.Size = new System.Drawing.Size(241, 24);
      this.aperçuavantimpressionToolStripMenuItem.Text = "Aperçu a&vant impression";
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new System.Drawing.Size(238, 6);
      // 
      // quitToolStripMenuItem
      // 
      this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
      this.quitToolStripMenuItem.Size = new System.Drawing.Size(241, 24);
      this.quitToolStripMenuItem.Text = "&Quitter";
      this.quitToolStripMenuItem.Click += new System.EventHandler(this.QuitToolStripMenuItemClick);
      // 
      // editionToolStripMenuItem
      // 
      this.editionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.annulerToolStripMenuItem,
            this.rétablirToolStripMenuItem,
            this.toolStripSeparator3,
            this.couperToolStripMenuItem,
            this.copierToolStripMenuItem,
            this.collerToolStripMenuItem,
            this.toolStripSeparator4,
            this.sélectionnertoutToolStripMenuItem});
      this.editionToolStripMenuItem.Name = "editionToolStripMenuItem";
      this.editionToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
      this.editionToolStripMenuItem.Text = "&Edition";
      // 
      // annulerToolStripMenuItem
      // 
      this.annulerToolStripMenuItem.Name = "annulerToolStripMenuItem";
      this.annulerToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
      this.annulerToolStripMenuItem.Size = new System.Drawing.Size(191, 24);
      this.annulerToolStripMenuItem.Text = "&Annuler";
      // 
      // rétablirToolStripMenuItem
      // 
      this.rétablirToolStripMenuItem.Name = "rétablirToolStripMenuItem";
      this.rétablirToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
      this.rétablirToolStripMenuItem.Size = new System.Drawing.Size(191, 24);
      this.rétablirToolStripMenuItem.Text = "&Rétablir";
      // 
      // toolStripSeparator3
      // 
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new System.Drawing.Size(188, 6);
      // 
      // couperToolStripMenuItem
      // 
      this.couperToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("couperToolStripMenuItem.Image")));
      this.couperToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.couperToolStripMenuItem.Name = "couperToolStripMenuItem";
      this.couperToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
      this.couperToolStripMenuItem.Size = new System.Drawing.Size(191, 24);
      this.couperToolStripMenuItem.Text = "&Couper";
      // 
      // copierToolStripMenuItem
      // 
      this.copierToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copierToolStripMenuItem.Image")));
      this.copierToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.copierToolStripMenuItem.Name = "copierToolStripMenuItem";
      this.copierToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
      this.copierToolStripMenuItem.Size = new System.Drawing.Size(191, 24);
      this.copierToolStripMenuItem.Text = "Co&pier";
      // 
      // collerToolStripMenuItem
      // 
      this.collerToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("collerToolStripMenuItem.Image")));
      this.collerToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.collerToolStripMenuItem.Name = "collerToolStripMenuItem";
      this.collerToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
      this.collerToolStripMenuItem.Size = new System.Drawing.Size(191, 24);
      this.collerToolStripMenuItem.Text = "Co&ller";
      // 
      // toolStripSeparator4
      // 
      this.toolStripSeparator4.Name = "toolStripSeparator4";
      this.toolStripSeparator4.Size = new System.Drawing.Size(188, 6);
      // 
      // sélectionnertoutToolStripMenuItem
      // 
      this.sélectionnertoutToolStripMenuItem.Name = "sélectionnertoutToolStripMenuItem";
      this.sélectionnertoutToolStripMenuItem.Size = new System.Drawing.Size(191, 24);
      this.sélectionnertoutToolStripMenuItem.Text = "Sélectio&nner tout";
      // 
      // outilsToolStripMenuItem
      // 
      this.outilsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
      this.outilsToolStripMenuItem.Name = "outilsToolStripMenuItem";
      this.outilsToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
      this.outilsToolStripMenuItem.Text = "&Outils";
      // 
      // optionsToolStripMenuItem
      // 
      this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
      this.optionsToolStripMenuItem.Size = new System.Drawing.Size(130, 24);
      this.optionsToolStripMenuItem.Text = "&Options";
      // 
      // languageToolStripMenuItem
      // 
      this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.frenchToolStripMenuItem,
            this.englishToolStripMenuItem});
      this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
      this.languageToolStripMenuItem.Size = new System.Drawing.Size(78, 24);
      this.languageToolStripMenuItem.Text = "Langage";
      // 
      // frenchToolStripMenuItem
      // 
      this.frenchToolStripMenuItem.Checked = true;
      this.frenchToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
      this.frenchToolStripMenuItem.Name = "frenchToolStripMenuItem";
      this.frenchToolStripMenuItem.Size = new System.Drawing.Size(131, 24);
      this.frenchToolStripMenuItem.Text = "Français";
      this.frenchToolStripMenuItem.Click += new System.EventHandler(this.FrenchToolStripMenuItemClick);
      // 
      // englishToolStripMenuItem
      // 
      this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
      this.englishToolStripMenuItem.Size = new System.Drawing.Size(131, 24);
      this.englishToolStripMenuItem.Text = "Anglais";
      this.englishToolStripMenuItem.Click += new System.EventHandler(this.EnglishToolStripMenuItemClick);
      // 
      // helpToolStripMenuItem
      // 
      this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
      this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
      this.helpToolStripMenuItem.Size = new System.Drawing.Size(52, 24);
      this.helpToolStripMenuItem.Text = "&Aide";
      // 
      // aboutToolStripMenuItem
      // 
      this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
      this.aboutToolStripMenuItem.Size = new System.Drawing.Size(169, 24);
      this.aboutToolStripMenuItem.Text = "À &propos de...";
      this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItemClick);
      // 
      // tabControl1
      // 
      this.tabControl1.Controls.Add(this.tabPageTranslation);
      this.tabControl1.Controls.Add(this.tabPageInput);
      this.tabControl1.Controls.Add(this.tabPageEditDictionary);
      this.tabControl1.Controls.Add(this.tabPageAutoLearning);
      this.tabControl1.Controls.Add(this.tabPageTool);
      this.tabControl1.Location = new System.Drawing.Point(12, 41);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(1415, 427);
      this.tabControl1.TabIndex = 1;
      // 
      // tabPageTranslation
      // 
      this.tabPageTranslation.Controls.Add(this.buttonConvert);
      this.tabPageTranslation.Controls.Add(this.labelTranslatedFileName);
      this.tabPageTranslation.Controls.Add(this.textBoxTranslatedFileName);
      this.tabPageTranslation.Controls.Add(this.textBoxSuffixeFileName);
      this.tabPageTranslation.Controls.Add(this.labelSuffixeFileName);
      this.tabPageTranslation.Controls.Add(this.buttonChooseFile);
      this.tabPageTranslation.Controls.Add(this.labelFilePath);
      this.tabPageTranslation.Controls.Add(this.textBoxfilePath);
      this.tabPageTranslation.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabPageTranslation.Location = new System.Drawing.Point(4, 25);
      this.tabPageTranslation.Name = "tabPageTranslation";
      this.tabPageTranslation.Padding = new System.Windows.Forms.Padding(3);
      this.tabPageTranslation.Size = new System.Drawing.Size(1107, 398);
      this.tabPageTranslation.TabIndex = 0;
      this.tabPageTranslation.Text = "Translate";
      this.tabPageTranslation.UseVisualStyleBackColor = true;
      
      // 
      // buttonConvert
      // 
      this.buttonConvert.Location = new System.Drawing.Point(987, 117);
      this.buttonConvert.Name = "buttonConvert";
      this.buttonConvert.Size = new System.Drawing.Size(93, 28);
      this.buttonConvert.TabIndex = 14;
      this.buttonConvert.Text = "Translate";
      this.buttonConvert.UseVisualStyleBackColor = true;
      this.buttonConvert.Click += new System.EventHandler(this.ButtonConvertClick);
      // 
      // labelTranslatedFileName
      // 
      this.labelTranslatedFileName.AutoSize = true;
      this.labelTranslatedFileName.Location = new System.Drawing.Point(31, 122);
      this.labelTranslatedFileName.Name = "labelTranslatedFileName";
      this.labelTranslatedFileName.Size = new System.Drawing.Size(145, 17);
      this.labelTranslatedFileName.TabIndex = 13;
      this.labelTranslatedFileName.Text = "Translated File name:";
      // 
      // textBoxTranslatedFileName
      // 
      this.textBoxTranslatedFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.textBoxTranslatedFileName.Location = new System.Drawing.Point(193, 122);
      this.textBoxTranslatedFileName.Name = "textBoxTranslatedFileName";
      this.textBoxTranslatedFileName.ReadOnly = true;
      this.textBoxTranslatedFileName.Size = new System.Drawing.Size(788, 22);
      this.textBoxTranslatedFileName.TabIndex = 12;
      // 
      // textBoxSuffixeFileName
      // 
      this.textBoxSuffixeFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.textBoxSuffixeFileName.Location = new System.Drawing.Point(193, 75);
      this.textBoxSuffixeFileName.Name = "textBoxSuffixeFileName";
      this.textBoxSuffixeFileName.Size = new System.Drawing.Size(201, 22);
      this.textBoxSuffixeFileName.TabIndex = 11;
      this.textBoxSuffixeFileName.Text = "_ENG";
      // 
      // labelSuffixeFileName
      // 
      this.labelSuffixeFileName.AutoSize = true;
      this.labelSuffixeFileName.Location = new System.Drawing.Point(31, 75);
      this.labelSuffixeFileName.Name = "labelSuffixeFileName";
      this.labelSuffixeFileName.Size = new System.Drawing.Size(156, 17);
      this.labelSuffixeFileName.TabIndex = 10;
      this.labelSuffixeFileName.Text = "Sufixe du fichier traduit:";
      // 
      // buttonChooseFile
      // 
      this.buttonChooseFile.Location = new System.Drawing.Point(1042, 28);
      this.buttonChooseFile.Name = "buttonChooseFile";
      this.buttonChooseFile.Size = new System.Drawing.Size(38, 23);
      this.buttonChooseFile.TabIndex = 9;
      this.buttonChooseFile.Text = "...";
      this.buttonChooseFile.UseVisualStyleBackColor = true;
      this.buttonChooseFile.Click += new System.EventHandler(this.ButtonChooseFileClick);
      // 
      // labelFilePath
      // 
      this.labelFilePath.AutoSize = true;
      this.labelFilePath.Location = new System.Drawing.Point(31, 28);
      this.labelFilePath.Name = "labelFilePath";
      this.labelFilePath.Size = new System.Drawing.Size(66, 17);
      this.labelFilePath.TabIndex = 8;
      this.labelFilePath.Text = "File path:";
      // 
      // textBoxfilePath
      // 
      this.textBoxfilePath.Location = new System.Drawing.Point(100, 28);
      this.textBoxfilePath.Name = "textBoxfilePath";
      this.textBoxfilePath.Size = new System.Drawing.Size(936, 22);
      this.textBoxfilePath.TabIndex = 7;
      this.textBoxfilePath.Text = "D:\\MesDoc";
      // 
      // tabPageInput
      // 
      this.tabPageInput.Controls.Add(this.buttonAddToDictionary);
      this.tabPageInput.Controls.Add(this.textBoxInputEnglish);
      this.tabPageInput.Controls.Add(this.labelInputEnglish);
      this.tabPageInput.Controls.Add(this.textBoxInputFrench);
      this.tabPageInput.Controls.Add(this.labelInputFrench);
      this.tabPageInput.Location = new System.Drawing.Point(4, 25);
      this.tabPageInput.Name = "tabPageInput";
      this.tabPageInput.Padding = new System.Windows.Forms.Padding(3);
      this.tabPageInput.Size = new System.Drawing.Size(1107, 398);
      this.tabPageInput.TabIndex = 1;
      this.tabPageInput.Text = "Input Dictionary";
      this.tabPageInput.UseVisualStyleBackColor = true;
      // 
      // buttonAddToDictionary
      // 
      this.buttonAddToDictionary.Location = new System.Drawing.Point(899, 369);
      this.buttonAddToDictionary.Name = "buttonAddToDictionary";
      this.buttonAddToDictionary.Size = new System.Drawing.Size(145, 23);
      this.buttonAddToDictionary.TabIndex = 4;
      this.buttonAddToDictionary.Text = "Add to dictionary";
      this.buttonAddToDictionary.UseVisualStyleBackColor = true;
      this.buttonAddToDictionary.Click += new System.EventHandler(this.ButtonAddToDictionaryClick);
      // 
      // textBoxInputEnglish
      // 
      this.textBoxInputEnglish.Location = new System.Drawing.Point(52, 237);
      this.textBoxInputEnglish.Multiline = true;
      this.textBoxInputEnglish.Name = "textBoxInputEnglish";
      this.textBoxInputEnglish.Size = new System.Drawing.Size(992, 117);
      this.textBoxInputEnglish.TabIndex = 3;
      // 
      // labelInputEnglish
      // 
      this.labelInputEnglish.AutoSize = true;
      this.labelInputEnglish.Location = new System.Drawing.Point(49, 207);
      this.labelInputEnglish.Name = "labelInputEnglish";
      this.labelInputEnglish.Size = new System.Drawing.Size(58, 17);
      this.labelInputEnglish.TabIndex = 2;
      this.labelInputEnglish.Text = "English:";
      // 
      // textBoxInputFrench
      // 
      this.textBoxInputFrench.Location = new System.Drawing.Point(52, 74);
      this.textBoxInputFrench.Multiline = true;
      this.textBoxInputFrench.Name = "textBoxInputFrench";
      this.textBoxInputFrench.Size = new System.Drawing.Size(992, 117);
      this.textBoxInputFrench.TabIndex = 1;
      // 
      // labelInputFrench
      // 
      this.labelInputFrench.AutoSize = true;
      this.labelInputFrench.Location = new System.Drawing.Point(49, 44);
      this.labelInputFrench.Name = "labelInputFrench";
      this.labelInputFrench.Size = new System.Drawing.Size(52, 17);
      this.labelInputFrench.TabIndex = 0;
      this.labelInputFrench.Text = "French";
      // 
      // tabPageEditDictionary
      // 
      this.tabPageEditDictionary.Location = new System.Drawing.Point(4, 25);
      this.tabPageEditDictionary.Name = "tabPageEditDictionary";
      this.tabPageEditDictionary.Size = new System.Drawing.Size(1107, 398);
      this.tabPageEditDictionary.TabIndex = 3;
      this.tabPageEditDictionary.Text = "Edit Dictionary";
      this.tabPageEditDictionary.UseVisualStyleBackColor = true;
      // 
      // tabPageAutoLearning
      // 
      this.tabPageAutoLearning.Controls.Add(this.buttonPickEnglishDocument);
      this.tabPageAutoLearning.Controls.Add(this.buttonPickFrenchDocument);
      this.tabPageAutoLearning.Controls.Add(this.textBoxEnglishDocument);
      this.tabPageAutoLearning.Controls.Add(this.labelEnglishDocument);
      this.tabPageAutoLearning.Controls.Add(this.textBoxFrenchDocument);
      this.tabPageAutoLearning.Controls.Add(this.labelFrenchDocument);
      this.tabPageAutoLearning.Controls.Add(this.buttonAutoLearning);
      this.tabPageAutoLearning.Location = new System.Drawing.Point(4, 25);
      this.tabPageAutoLearning.Name = "tabPageAutoLearning";
      this.tabPageAutoLearning.Size = new System.Drawing.Size(1407, 398);
      this.tabPageAutoLearning.TabIndex = 4;
      this.tabPageAutoLearning.Text = "Automatic Learing";
      this.tabPageAutoLearning.UseVisualStyleBackColor = true;
      // 
      // buttonPickEnglishDocument
      // 
      this.buttonPickEnglishDocument.Location = new System.Drawing.Point(1351, 90);
      this.buttonPickEnglishDocument.Name = "buttonPickEnglishDocument";
      this.buttonPickEnglishDocument.Size = new System.Drawing.Size(38, 23);
      this.buttonPickEnglishDocument.TabIndex = 11;
      this.buttonPickEnglishDocument.Text = "...";
      this.buttonPickEnglishDocument.UseVisualStyleBackColor = true;
      this.buttonPickEnglishDocument.Click += new System.EventHandler(this.ButtonPickEnglishDocumentClick);
      // 
      // buttonPickFrenchDocument
      // 
      this.buttonPickFrenchDocument.Location = new System.Drawing.Point(1351, 47);
      this.buttonPickFrenchDocument.Name = "buttonPickFrenchDocument";
      this.buttonPickFrenchDocument.Size = new System.Drawing.Size(38, 23);
      this.buttonPickFrenchDocument.TabIndex = 10;
      this.buttonPickFrenchDocument.Text = "...";
      this.buttonPickFrenchDocument.UseVisualStyleBackColor = true;
      this.buttonPickFrenchDocument.Click += new System.EventHandler(this.ButtonPickFrenchDocumentClick);
      // 
      // textBoxEnglishDocument
      // 
      this.textBoxEnglishDocument.Location = new System.Drawing.Point(141, 91);
      this.textBoxEnglishDocument.Name = "textBoxEnglishDocument";
      this.textBoxEnglishDocument.Size = new System.Drawing.Size(1204, 22);
      this.textBoxEnglishDocument.TabIndex = 4;
      // 
      // labelEnglishDocument
      // 
      this.labelEnglishDocument.AutoSize = true;
      this.labelEnglishDocument.Location = new System.Drawing.Point(13, 91);
      this.labelEnglishDocument.Name = "labelEnglishDocument";
      this.labelEnglishDocument.Size = new System.Drawing.Size(124, 17);
      this.labelEnglishDocument.TabIndex = 3;
      this.labelEnglishDocument.Text = "English document:";
      // 
      // textBoxFrenchDocument
      // 
      this.textBoxFrenchDocument.Location = new System.Drawing.Point(141, 47);
      this.textBoxFrenchDocument.Name = "textBoxFrenchDocument";
      this.textBoxFrenchDocument.Size = new System.Drawing.Size(1204, 22);
      this.textBoxFrenchDocument.TabIndex = 2;
      // 
      // labelFrenchDocument
      // 
      this.labelFrenchDocument.AutoSize = true;
      this.labelFrenchDocument.Location = new System.Drawing.Point(13, 47);
      this.labelFrenchDocument.Name = "labelFrenchDocument";
      this.labelFrenchDocument.Size = new System.Drawing.Size(122, 17);
      this.labelFrenchDocument.TabIndex = 1;
      this.labelFrenchDocument.Text = "French document:";
      // 
      // buttonAutoLearning
      // 
      this.buttonAutoLearning.Location = new System.Drawing.Point(16, 139);
      this.buttonAutoLearning.Name = "buttonAutoLearning";
      this.buttonAutoLearning.Size = new System.Drawing.Size(121, 28);
      this.buttonAutoLearning.TabIndex = 0;
      this.buttonAutoLearning.Text = "Auto learning";
      this.buttonAutoLearning.UseVisualStyleBackColor = true;
      // 
      // tabPageTool
      // 
      this.tabPageTool.Controls.Add(this.buttonWords);
      this.tabPageTool.Controls.Add(this.buttonCountParagraph);
      this.tabPageTool.Location = new System.Drawing.Point(4, 25);
      this.tabPageTool.Name = "tabPageTool";
      this.tabPageTool.Size = new System.Drawing.Size(1107, 398);
      this.tabPageTool.TabIndex = 2;
      this.tabPageTool.Text = "Tools";
      this.tabPageTool.UseVisualStyleBackColor = true;
      // 
      // buttonWords
      // 
      this.buttonWords.Location = new System.Drawing.Point(44, 101);
      this.buttonWords.Name = "buttonWords";
      this.buttonWords.Size = new System.Drawing.Size(136, 27);
      this.buttonWords.TabIndex = 1;
      this.buttonWords.Text = "Count words";
      this.buttonWords.UseVisualStyleBackColor = true;
      this.buttonWords.Click += new System.EventHandler(this.ButtonWordsClick);
      // 
      // buttonCountParagraph
      // 
      this.buttonCountParagraph.Location = new System.Drawing.Point(44, 51);
      this.buttonCountParagraph.Name = "buttonCountParagraph";
      this.buttonCountParagraph.Size = new System.Drawing.Size(136, 27);
      this.buttonCountParagraph.TabIndex = 0;
      this.buttonCountParagraph.Text = "Count paragraph";
      this.buttonCountParagraph.UseVisualStyleBackColor = true;
      this.buttonCountParagraph.Click += new System.EventHandler(this.ButtonCountParagraphClick);
      // 
      // openFileDialog1
      // 
      this.openFileDialog1.FileName = "openFileDialog1";
      // 
      // FormMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1449, 537);
      this.Controls.Add(this.tabControl1);
      this.Controls.Add(this.menuStrip1);
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "FormMain";
      this.Text = "Translator Helper";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMainFormClosing);
      this.Load += new System.EventHandler(this.FormMainLoad);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.tabControl1.ResumeLayout(false);
      this.tabPageTranslation.ResumeLayout(false);
      this.tabPageTranslation.PerformLayout();
      this.tabPageInput.ResumeLayout(false);
      this.tabPageInput.PerformLayout();
      this.tabPageAutoLearning.ResumeLayout(false);
      this.tabPageAutoLearning.PerformLayout();
      this.tabPageTool.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem nouveauToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem ouvrirToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
    private System.Windows.Forms.ToolStripMenuItem enregistrerToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem enregistrersousToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripMenuItem imprimerToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem aperçuavantimpressionToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem editionToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem annulerToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem rétablirToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    private System.Windows.Forms.ToolStripMenuItem couperToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem copierToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem collerToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    private System.Windows.Forms.ToolStripMenuItem sélectionnertoutToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem outilsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabPageTranslation;
    private System.Windows.Forms.TabPage tabPageInput;
    private System.Windows.Forms.OpenFileDialog openFileDialog1;
    private System.Windows.Forms.Button buttonConvert;
    private System.Windows.Forms.Label labelTranslatedFileName;
    private System.Windows.Forms.TextBox textBoxTranslatedFileName;
    private System.Windows.Forms.TextBox textBoxSuffixeFileName;
    private System.Windows.Forms.Label labelSuffixeFileName;
    private System.Windows.Forms.Button buttonChooseFile;
    private System.Windows.Forms.Label labelFilePath;
    private System.Windows.Forms.TextBox textBoxfilePath;
    private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem frenchToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
    private System.Windows.Forms.TabPage tabPageTool;
    private System.Windows.Forms.Button buttonCountParagraph;
    private System.Windows.Forms.Button buttonAddToDictionary;
    private System.Windows.Forms.TextBox textBoxInputEnglish;
    private System.Windows.Forms.Label labelInputEnglish;
    private System.Windows.Forms.TextBox textBoxInputFrench;
    private System.Windows.Forms.Label labelInputFrench;
    private System.Windows.Forms.TabPage tabPageEditDictionary;
    private System.Windows.Forms.Button buttonWords;
    private System.Windows.Forms.TabPage tabPageAutoLearning;
    private System.Windows.Forms.Button buttonPickEnglishDocument;
    private System.Windows.Forms.Button buttonPickFrenchDocument;
    private System.Windows.Forms.TextBox textBoxEnglishDocument;
    private System.Windows.Forms.Label labelEnglishDocument;
    private System.Windows.Forms.TextBox textBoxFrenchDocument;
    private System.Windows.Forms.Label labelFrenchDocument;
    private System.Windows.Forms.Button buttonAutoLearning;
  }
}

