import unittest
import json
from pathlib import Path
from prepare_osm_terrain import utm

class TerrainDataTests(unittest.TestCase):
    def test_projection_central_meridian(self):
        x,z=utm(0,99)
        self.assertAlmostEqual(x,500000,places=5)
        self.assertAlmostEqual(z,0,places=5)
    def test_export(self):
        data=json.loads(Path('Assets/WorldPrototype/Data/ayutthaya.json').read_text())
        self.assertGreater(len(data['roads']),0)
        self.assertEqual(data['width']%512,0)
        self.assertEqual(data['length']%512,0)
        for road in data['roads']:
            self.assertGreaterEqual(len(road['points']),2)
            self.assertTrue(1<=road['width']<=30)
        report=json.loads(Path('Assets/WorldPrototype/Data/ayutthaya.report.json').read_text(encoding='utf8'))
        self.assertGreater(report['excludedBuildings'],0)
        self.assertEqual(report['missingNodeWays'],0)
    def test_metre_scale(self):
        a=utm(14.35,100.55); b=utm(14.35001,100.55)
        self.assertTrue(1.10 < b[1]-a[1] < 1.12)

if __name__=='__main__': unittest.main()
