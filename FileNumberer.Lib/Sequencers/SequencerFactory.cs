using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileNumberer.Lib.Sequencers
{
    class SequencerFactory
    {
        public static FileSequencer GetSequencer(SequenceMethod method)
        {
            FileSequencer sequencer = null;

            switch(method)
            {
                case SequenceMethod.Alphabetical:
                    sequencer = new AlphabeticalSequencer();
                    break;
            }

            return sequencer;
        }
    }
}
