import pandas as pd
import sys
from pgmpy.models import BayesianModel
from pgmpy.inference import VariableElimination

data = pd.read_csv(sys.argv[1])

model = BayesianModel([(),(),()])
model.fit(data)

data_inference = VariableElimination(model)

qry = data_inference.query(variables=[""], evidence )