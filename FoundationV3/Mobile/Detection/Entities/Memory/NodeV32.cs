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

using FiftyOne.Foundation.Mobile.Detection.Factories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FiftyOne.Foundation.Mobile.Detection.Entities.Memory
{
    /// <summary>
    /// All data is loaded into memory when the entity is constructed.
    /// </summary>
    internal class NodeV32 : Node
    {
        #region Constructors

        /// <summary>
        /// Constructs a new instance of <see cref="NodeV32"/>
        /// </summary>
        /// <param name="dataSet">
        /// The data set the node is contained within
        /// </param>
        /// <param name="offset">
        /// The offset in the data structure to the node
        /// </param>
        /// <param name="reader">
        /// Reader connected to the source data structure and positioned to start reading
        /// </param>
        internal NodeV32(
            DataSet dataSet,
            int offset,
            BinaryReader reader)
            : base(dataSet, offset, reader)
        {
            if (RankedSignatureCount > 0)
            {
                _nodeRankedSignatureValue = reader.ReadInt32();
            }
        }

        #endregion  
        
        #region Overrides

        /// <summary>
        /// Reads the ranked signature count from a 2 byte ushort.
        /// </summary>
        /// <param name="reader">
        /// Reader connected to the source data structure and positioned to start reading
        /// </param>
        /// <returns>The count of ranked signatures associated with the node.</returns>
        protected override int ReaderRankedSignatureCount(BinaryReader reader)
        {
            return reader.ReadUInt16();
        }

        /// <summary>
        /// Loads all the ranked signature indexes for the node.
        /// </summary>
        internal override void Init()
        {
            base.Init();
            if (_rankedSignatureIndexes == null)
            {
                _rankedSignatureIndexes = GetRankedSignatureIndexesAsArray();
            }
        }

        internal override int[] RankedSignatureIndexes
        {
            get 
            {
                if (_rankedSignatureIndexes == null)
                {
                    lock (this)
                    {
                        if (_rankedSignatureIndexes == null)
                        {
                            _rankedSignatureIndexes = GetRankedSignatureIndexesAsArray();
                        }
                    }
                }
                return _rankedSignatureIndexes; 
            }
        }
        private int[] _rankedSignatureIndexes;
        private int _nodeRankedSignatureValue;
                
        private int[] GetRankedSignatureIndexesAsArray()
        {
            var rankedSignatureIndexes = new int[RankedSignatureCount];
            if (RankedSignatureCount == 1)
            {
                // The value of _nodeRankedSignatureIndex is the ranked signature
                // index when the node only relates to 1 signature.
                rankedSignatureIndexes[0] = _nodeRankedSignatureValue;
            }
            else if (RankedSignatureCount > 1)
            {
                // Where the node relates to multiple signatures the _nodeRankedSignatureIndex
                // relates to the first ranked signature index in DataSet.NodeRankedSignatureIndexes.
                for (int i = 0; i < RankedSignatureCount; i++)
                {
                    rankedSignatureIndexes[i] = DataSet.NodeRankedSignatureIndexes[_nodeRankedSignatureValue + i].Value;
                }
            }
            return rankedSignatureIndexes;
        }

        /// <summary>
        /// Used by the constructor to read the variable length list of child
        /// node indexes associated with the node. Returns node indexes from V32
        /// data format.
        /// </summary>
        /// <param name="dataSet">
        /// The data set the node is contained within
        /// </param>
        /// <param name="reader">
        /// Reader connected to the source data structure and positioned to start reading
        /// </param>
        /// <param name="offset">
        /// The offset in the data structure to the node
        /// </param>
        /// <param name="count">
        /// The number of node indexes that need to be read.
        /// </param>
        /// <returns>An array of child node indexes for the node</returns>
        protected override NodeIndex[] ReadNodeIndexes(Entities.DataSet dataSet, BinaryReader reader, int offset, int count)
        {
            return NodeFactoryShared.ReadNodeIndexesV32(dataSet, reader, offset, count);
        }

        #endregion
    }
}
