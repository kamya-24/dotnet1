﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using SmartStore.Core;

namespace SmartStore.Rules.Domain
{
    public partial class RuleSet // : BaseEntity
    {
        private ICollection<RuleEntity> _rules;

        [DataMember]
        [StringLength(200)]
        public string Name { get; set; }

        [DataMember]
        [StringLength(400)]
        public string Description { get; set; }

        public bool IsActive { get; set; } = true;

        /// <summary>
        /// True when this set is an internal composite container for rules within another ruleset.
        /// </summary>
        public bool IsComposite { get; set; }

        /// <summary>
        /// Only applicable if <see cref="IsComposite"/> is true (???)
        /// </summary>
        public LogicalRuleOperator LogicalOperator { get; set; }

        public virtual ICollection<RuleEntity> Rules
        {
            get { return _rules ?? (_rules = new HashSet<RuleEntity>()); }
            protected set { _rules = value; }
        }
    }
}