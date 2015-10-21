﻿/* *********************************************************************
 * This Source Code Form is copyright of 51Degrees Mobile Experts Limited. 
 * Copyright © 2015 51Degrees Mobile Experts Limited, 5 Charlotte Close,
 * Caversham, Reading, Berkshire, United Kingdom RG4 7BY
 * 
 * This Source Code Form is the subject of the following patent 
 * applications, owned by 51Degrees Mobile Experts Limited of 5 Charlotte
 * Close, Caversham, Reading, Berkshire, United Kingdom RG4 7BY: 
 * European Patent Application No. 13192291.6; and
 * United States Patent Application Nos. 14/085,223 and 14/085,301.
 *
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0.
 * 
 * If a copy of the MPL was not distributed with this file, You can obtain
 * one at http://mozilla.org/MPL/2.0/.
 * 
 * This Source Code Form is “Incompatible With Secondary Licenses”, as
 * defined by the Mozilla Public License, v. 2.0.
 * ********************************************************************* */
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FiftyOne.Foundation.Mobile.Detection.Factories;
using System.IO;

namespace FiftyOne.UnitTests.MetaData.Lite
{
    [TestClass]
    public class V32Memory : Base
    {
        protected override string DataFile
        {
            get { return Constants.LITE_PATTERN_V32; }
        }

        [TestInitialize()]
        public void CreateDataSet()
        {
            Utils.CheckFileExists(DataFile);
            _dataSet = MemoryFactory.Create(DataFile);
        }

        [TestMethod]
        public void LiteV32Memory_RetrieveComponents() { base.RetrieveComponents(); }

        [TestMethod]
        public void LiteV32Memory_RetrieveProperties() { base.RetrieveProperties(); }

        [TestMethod]
        public void LiteV32Memory_RetrieveValues() { base.RetrieveValues(); }

        [TestMethod]
        public void LiteV32Memory_CheckPropertyCount() { base.CheckPropertyCount(57); }

        [TestMethod]
        public void LiteV32Memory_ValidatePropertiesHaveDescription() { base.ValidatePropertiesHaveDescription(); }
    }
}