﻿namespace inlämningsuppgift
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private Button colorButton;
        private Button clearButton;
        private Button undoButton;
        private Button redoButton;
        private Button saveButton;
        private Button openButton;
        private Panel drawingPanel;
        private ComboBox toolBox;
    }
}
