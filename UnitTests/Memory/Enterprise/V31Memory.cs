﻿/* *********************************************************************
 * This Source Code Form is copyright of 51Degrees Mobile Experts Limited. 
 * Copyright © 2014 51Degrees Mobile Experts Limited, 5 Charlotte Close,
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
using FiftyOne.Foundation.Mobile.Detection;

namespace FiftyOne.UnitTests.Memory.Enterprise
{
    [TestClass]
    public class V31Memory : Memory
    {
        protected override string DataFile
        {
            get { return Constants.ENTERPRISE_PATTERN_V31; }
        }

        [TestMethod]
        public void EnterpriseV31Memory_Memory_UniqueUserAgentsMulti()
        {
            base.UserAgentsMulti(File.ReadAllLines(Constants.GOOD_USERAGENTS_FILE), 1200);
        }

        [TestMethod]
        public void EnterpriseV31Memory_Memory_UniqueUserAgentsSingle()
        {
            base.UserAgentsSingle(File.ReadAllLines(Constants.GOOD_USERAGENTS_FILE), 1200);
        }

        [TestMethod]
        public void EnterpriseV31Memory_Memory_RandomUserAgentsMulti()
        {
            base.UserAgentsMulti(UserAgentGenerator.GetRandomUserAgents(), 1200);
        }

        [TestMethod]
        public void EnterpriseV31Memory_Memory_RandomUserAgentsSingle()
        {
            base.UserAgentsSingle(UserAgentGenerator.GetRandomUserAgents(), 1200);
        }

        [TestMethod]
        public void EnterpriseV31Memory_Memory_BadUserAgentsMulti()
        {
            base.UserAgentsMulti(UserAgentGenerator.GetBadUserAgents(), 1200);
        }

        [TestMethod]
        public void EnterpriseV31Memory_Memory_BadUserAgentsSingle()
        {
            base.UserAgentsSingle(UserAgentGenerator.GetBadUserAgents(), 1200);
        }
    }
}
