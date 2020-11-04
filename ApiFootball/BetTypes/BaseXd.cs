using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Api.Data.Models;

namespace ApiFootball.BetTypes
{
    public abstract class BaseXd<T> where T : BaseBetType
    {
        public const string Name = "Label";

        public T BetType { get; set; }

        public Bet Bet { get; set; }

        public int LabelId { get; set; }


        protected BaseXd()
        {
        }

        protected BaseXd(Bet bet)
        {
            Bet = bet;
        }

        public virtual T GenerateBetType()
        {
            ValidateBet();
            SetLabelId();
            CheckExtLabelId();
            InitializeBetType();
            ParseDataFromBetToBetType();
            DeleteOddValuesWithoutOdds();
            return BetType;
        }

        public virtual T GenerateBetType(Bet bet)
        {
            Bet = bet;
            ValidateBet();
            SetLabelId();
            CheckExtLabelId();
            InitializeBetType();
            ParseDataFromBetToBetType();
            DeleteOddValuesWithoutOdds();
            return BetType;
        }


        protected virtual void ValidateBet()
        {
            if (Bet == null)
                throw new ArgumentException("Bet is null", "Bet");

            if (Bet.Label == null)
                throw new ArgumentException("Bet label is null", "Bet.Label");

            if (Bet.BetValues == null || Bet.BetValues.Count == 0)
                throw new ArgumentException("Bet values is null or empty", "Bet.BetValues");
        }

        protected virtual void CheckExtLabelId()
        {
            if (Bet.Label.ExtLabelId != LabelId)
            {
                throw new Exception("Incorrect label type, " + "ExtLabelId: " + Bet.Label.ExtLabelId
                                    + ". Expected ExtLAbelId: " + LabelId);
            }
        }

        protected abstract void InitializeBetType();

        protected abstract void SetLabelId();

        public virtual void ParseDataFromBetToBetType()
        {
            foreach (var betValue in Bet.BetValues)
            {
                var oddValue =
                    BetType.OddValues.FirstOrDefault(
                        x => x.Value == betValue.Value);

                if (oddValue == null)
                    throw new Exception("BetValues don't contain value: " + betValue.Value);

                oddValue.Odd = betValue.Odd;
                oddValue.Id = betValue.Id;
            }

            BetType.OddId = Bet.OddId;
            BetType.LabelId = Bet.LabelId;
        }

        public virtual void DeleteOddValuesWithoutOdds()
        {
            foreach (var oddValue in BetType.OddValues.ToList().Where(oddValue => oddValue.Odd == 0))
            {
                BetType.OddValues.Remove(oddValue);
            }
        }


    }
}
